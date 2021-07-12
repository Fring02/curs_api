using AutoMapper;
using CURS.Domain.Dtos;
using CURS.Domain.Interfaces.Core;
using CURS.Domain.Interfaces.Data;
using CURS.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CURS.Infrastructure.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TEntityViewDto> : IRepository<TEntity, TEntityViewDto>
        where TEntity : IEntity where TEntityViewDto : IDto
    {
        protected readonly MongoContext _context;
        protected readonly IMapper _mapper;
        public BaseRepository(MongoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public abstract Task CreateAsync(TEntity model);

        public Task DeleteAsync(TEntity model)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IReadOnlyCollection<TEntityViewDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync<TId>(TId id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
