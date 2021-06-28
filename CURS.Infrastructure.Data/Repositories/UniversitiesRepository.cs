using CURS.Domain.Core.Models;
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
    public class UniversitiesRepository : IUniversitiesRepository<UniversityViewDto>
    {
        private MongoContext _context;

        public UniversitiesRepository(MongoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UniversityViewDto>> GetByFilter(string name)
        {
            var regex = new BsonRegularExpression(name);
            var filter = Builders<UniversityDocument>.Filter.Or(new[]
            {
                Builders<UniversityDocument>.Filter.Regex("Name.NameEn", regex),
                Builders<UniversityDocument>.Filter.Regex("Name.NameKk", regex),
                Builders<UniversityDocument>.Filter.Regex("Name.NameRu", regex),
            });
            return await _context.Universities.Find(filter).
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
    }
}
