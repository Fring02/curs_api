using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CURS.Domain.Interfaces.Data
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(T model);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<T> GetByIdAsync<TId>(TId id);
    }
}
