﻿using CURS.Domain.Core.Models;
using CURS.Domain.Dtos;
using CURS.Domain.Interfaces.Data;
using CURS.Infrastructure.Data.Contexts;
using CURS.Infrastructure.Data.Documents;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CURS.Infrastructure.Data.Repositories
{
    public class UniversitiesRepository : BaseRepository<University>, IUniversitiesRepository
    {
        public UniversitiesRepository(MongoContext context) : base(context)
        {
            _context = context;
        }

        public override Task CreateAsync(University model)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(University model)
        {
            throw new NotImplementedException();
        }

        public override Task<IReadOnlyCollection<TEntityDto>> GetAllAsync<TEntityDto>()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UniversityViewDto>> GetByFilter(UniversityFilterDto filter)
        {
            FilterDefinition<UniversityDocument> filterExpression = Builders<UniversityDocument>.Filter.Empty;
            if (!string.IsNullOrEmpty(filter.Name))
            {
                var regex = new BsonRegularExpression(filter.Name);
                filterExpression &= Builders<UniversityDocument>.Filter.Or(new[]
                {
                    Builders<UniversityDocument>.Filter.Regex("Name.NameEn", regex),
                    Builders<UniversityDocument>.Filter.Regex("Name.NameKk", regex),
                    Builders<UniversityDocument>.Filter.Regex("Name.NameRu", regex),
                });
            }
            if(filter.ExtraId > 0)
            {
                filterExpression &= Builders<UniversityDocument>.Filter.Eq("ExtraId", filter.ExtraId);
            }
            if(filter.DateModified != default)
            {
                var tomorrow = filter.DateModified.AddDays(1);
                filterExpression &= Builders<UniversityDocument>.Filter.Where(u =>
                u.DateModified >= filter.DateModified && u.DateModified < tomorrow);
            }
            if(filter.DateOfCreation != default)
            {
                var tomorrow = filter.DateOfCreation.AddDays(1);
                filterExpression &= Builders<UniversityDocument>.Filter.Where(u =>
                u.DateOfCreation >= filter.DateOfCreation && u.DateOfCreation < tomorrow);
            }
            return await _context.Universities.Find(filterExpression).
                Project(Builders<UniversityDocument>.Projection
                .Expression(u => new UniversityViewDto
                {
                    DateModified = u.DateModified,
                    DateOfCreation = u.DateOfCreation,
                    ExtraId = u.ExtraId,
                    Name = u.Name,
                })).
                ToListAsync();
        }

        public override Task<University> GetByIdAsync<TId>(TId id)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(University model)
        {
            throw new NotImplementedException();
        }
    }
}
