using Hepsiapi.Application.Interfaces.Repositories;
using Hepsiapi.Application.UnitOfWorks;
using HepsiApi.PresisTence.Context;
using HepsiApi.PresisTence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.PresisTence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

       // public async ValueTask DisposeAsync()=> await dbContext.DisposeAsync(); // bu şekilde de kullanılabilir.
        public ValueTask DisposeAsync()
        {
             return dbContext.DisposeAsync();
        }

        public int save() => dbContext.SaveChanges();
        //{
        //    throw new NotImplementedException();
        //}

        public Task<int> SaveAsync()
        {
          return dbContext.SaveChangesAsync();
        }

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>()=> new ReadRepository<T>(dbContext);
       

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()
        {
           return new WriteRepository<T>(dbContext);
        }
    }
}
