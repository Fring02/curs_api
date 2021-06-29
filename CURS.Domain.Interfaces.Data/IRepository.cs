﻿using CURS.Domain.Dtos;
using CURS.Domain.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CURS.Domain.Interfaces.Data
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task CreateAsync(TEntity model);
        Task UpdateAsync(TEntity model);
        Task DeleteAsync(TEntity model);
        Task<IReadOnlyCollection<TEntityDto>> GetAllAsync<TEntityDto>() where TEntityDto : IDto;
        Task<TEntity> GetByIdAsync<TId>(TId id);
    }
}
