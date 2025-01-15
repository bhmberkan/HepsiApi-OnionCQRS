using Hepsiapi.Application.Interfaces.Repositories;
using Hepsiapi.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.PresisTence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext dbContext;

        public ReadRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> Table { get => dbContext.Set<T>(); }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? Orderby = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking(); // sadece okuma yapacağımız için tracik mekanızmasını devre dışı bırakıyoruz.
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate); // queryable'lere opsiyonlar yazdık farkı by orderby ile
            if (Orderby is not null)
                return await Orderby(queryable).ToListAsync(); // listeleme işlemi yaptığımız için return ediyoruz // liste döndürdük

            return await queryable.ToListAsync();
        }

        public async Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? Orderby = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking(); // sadece okuma yapacağımız için tracik mekanızmasını devre dışı bırakıyoruz.
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate); // queryable'lere opsiyonlar yazdık farkı by orderby ile
            if (Orderby is not null)
                return await Orderby(queryable).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync(); // listeleme işlemi yaptığımız için return ediyoruz // liste döndürdük

            return await queryable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        // pagesize = 3
        // currentPage = 1 ise 1-1 = 0 bu işlemin sonucu 0 pagesize kadar veriyi getirir
        // currentPage = 2 ise 2-1 = 1 * 3 (3)pagesize kadar veriyi getirir
        // currentPage = 3 ise 3-1 = 2 * pagesize = 6 olur 6 veri getirir


        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking(); // sadece okuma yapacağımız için tracik mekanızmasını devre dışı bırakıyoruz.
            if (include is not null) queryable = include(queryable);

            // queryable.Where(predicate);

            return await queryable.FirstOrDefaultAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking();
            if (predicate is not null) Table.Where(predicate);

            return await Table.CountAsync();
        }

        public   IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
        {
            if (!enableTracking) Table.AsNoTracking();

            return  Table.Where(predicate);
        }






    }
}
