using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CURS.Domain.Dtos;
using CURS.Domain.Dtos.Filter;
using CURS.Domain.Interfaces.Data;
using CURS.Infrastructure.Data.Contexts;
using CURS.Infrastructure.Data.Documents;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CURS.Infrastructure.Data.Repositories
{
    public class QsExpertFieldsRepository : IQsExpertFieldsRepository
    {
        private readonly MongoContext _context;
        private readonly IMapper _mapper;
        public QsExpertFieldsRepository(MongoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<EntitiesFieldsDto> GetByFields(QsExpertFieldsFilterDto filter)
        {
            var result = new EntitiesFieldsDto();
            if (filter.Boolean)
            {
                result.Booleans = await _context.Booleans.Find(_ => true).Project(Builders<BooleanDocument>
                    .Projection.Expression(c => _mapper.Map<NameDto>(c.Name))).ToListAsync();
            }
            if (filter.University)
            {
                result.Universities = await _context.Universities.Find(_ => true).Project(Builders<UniversityDocument>
                    .Projection.Expression(c => _mapper.Map<NameDto>(c.Name))).ToListAsync();
            }
            if (filter.Country)
            {
                result.Countries = await _context.Countries.Find(_ => true).Project(Builders<CountryDocument>
                    .Projection.Expression(c => _mapper.Map<NameDto>(c.Name))).ToListAsync();
            }
            if (filter.Qs)
            {
                result.Qss = await _context.QS.Find(_ => true).Project(Builders<QSDocument>
                    .Projection.Expression(c => _mapper.Map<NameDto>(c.Name))).ToListAsync();
            }
            if (filter.Position)
            {
                result.Positions = await _context.QSExperts.Find(_ => true).Project(Builders<QsExpertDocument>
                    .Projection.Expression(c => c.Position)).ToListAsync();
            }
            if (filter.Email)
            {
                result.Emails = await _context.QSExperts.Find(_ => true).Project(Builders<QsExpertDocument>
                    .Projection.Expression(c => c.Employer.Email)).ToListAsync();
            }
            if (filter.Title)
            {
                result.Titles = await _context.Titles.Find(_ => true).Project(Builders<TitleDocument>
                    .Projection.Expression(c => _mapper.Map<NameDto>(c.Name))).ToListAsync();
            }
            if (filter.BirthDate)
            {
                result.BirthDates = await _context.QSExperts.Find(_ => true).Project(Builders<QsExpertDocument>
                    .Projection.Expression(c => c.Employer.BirthDate)).ToListAsync();
            }
            if (filter.Unit)
            {
                result.Units = await _context.QSExperts.Find(_ => true).Project(Builders<QsExpertDocument>
                    .Projection.Expression(c => c.Unit)).ToListAsync();
            }
            if (filter.EmpUniversity)
            {
                result.EmpUniversities = await _context.QSExperts.Find(_ => true).Project(Builders<QsExpertDocument>
                    .Projection.Expression(c => c.EmpUniversity)).ToListAsync();
            }
            if (filter.MobileNumber)
            {
                result.MobileNumbers = await _context.QSExperts.Find(_ => true).Project(Builders<QsExpertDocument>
                    .Projection.Expression(c => c.Employer.MobileNumber)).ToListAsync();
            }
            if (filter.FioRu)
            {
                result.FioRus = await _context.QSExperts.Find(_ => true).Project(Builders<QsExpertDocument>
                    .Projection
                    .Expression(q => q.Employer.SurNameRu + " " + q.Employer.FirstNameRu + " " + q.Employer.MiddleNameRu))
                    .ToListAsync();
            }
            if (filter.FioEn)
            {
                result.FioEngs = await _context.QSExperts.Find(_ => true).Project(Builders<QsExpertDocument>
                        .Projection
                        .Expression(q => q.Employer.SurNameEn + " " + q.Employer.FirstNameEn + " " + q.Employer.MiddleNameEn))
                    .ToListAsync();
            }
            return result;
        }
    }
}