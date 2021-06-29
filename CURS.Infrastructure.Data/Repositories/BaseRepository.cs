using CURS.Domain.Dtos;
using CURS.Domain.Interfaces.Core;
using CURS.Domain.Interfaces.Data;
using CURS.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CURS.Infrastructure.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        protected MongoContext _context;
        public BaseRepository(MongoContext context)
        {
            _context = context;
        }
        public abstract Task CreateAsync(TEntity model);

        public abstract Task DeleteAsync(TEntity model);

        public abstract Task<IReadOnlyCollection<TEntityDto>> GetAllAsync<TEntityDto>() where TEntityDto : IDto;

        public abstract Task<TEntity> GetByIdAsync<TId>(TId id);

        public abstract Task UpdateAsync(TEntity model);
    }
}
