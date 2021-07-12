using CURS.Domain.Dtos;
using CURS.Domain.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CURS.Domain.Interfaces.Data
{
    public interface IRepository<TEntity, TEntityViewDto> where TEntity : IEntity where TEntityViewDto : IDto
    {
        Task CreateAsync(TEntity model);
        Task UpdateAsync(TEntity model);
        Task DeleteAsync(TEntity model);
        Task<IReadOnlyCollection<TEntityViewDto>> GetAllAsync();
        Task<TEntity> GetByIdAsync<TId>(TId id);
    }
}
