using System;
using Hepsiapi.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : class, IEntityBase, new()
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities); // liste alırsak  hangılerı eklendı tamamını seçebiliriz.

        Task<T> UpdateAsync(T entity);

     // Task DeleteAsync(T entity); // int id de verebiliriz. ancak ıd stringse patlar

        Task HardDeleteAsync(T entity);
        Task HardDeleteRangeAsync(IList<T> entity);



    }
}
