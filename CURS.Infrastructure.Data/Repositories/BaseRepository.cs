using AutoMapper;
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
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        protected MongoContext _context;
        protected IMapper _mapper;
        public BaseRepository(MongoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task CreateAsync(TEntity model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity model)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<TEntityDto>> GetAllAsync<TEntityDto>() where TEntityDto : IDto
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
