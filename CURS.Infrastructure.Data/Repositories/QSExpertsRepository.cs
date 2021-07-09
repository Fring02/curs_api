using AutoMapper;
using CURS.Domain.Core.Models;
using CURS.Domain.Dtos;
using CURS.Domain.Interfaces.Data;
using CURS.Infrastructure.Data.Contexts;
using CURS.Infrastructure.Data.Documents;
using CURS.Infrastructure.Data.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using CURS.Domain.Core.Exceptions;
using CURS.Domain.Dtos.Filter;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CURS.Infrastructure.Data.Repositories
{
    public class QSExpertsRepository : BaseRepository<QSExpert, QSExpertViewDto>, IQSExpertsRepository
    {
        private QSExpertFilterBuilder _builder;
        public QSExpertsRepository(MongoContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IReadOnlyCollection<QSExpertViewDto>> GetByFilter(QSExpertFilterDto filter)
        {
            _builder = new QSExpertFilterBuilder(_context, _mapper);
            if(filter.Employer != null)
            {
                _builder = _builder.WithBirthDate(filter.Employer.BirthDate)
                .WithEmail(filter.Employer.Email)
                .WithFirstnameEn(filter.Employer.FirstNameEn)
                .WithSurnameEn(filter.Employer.SurNameEn)
                .WithMiddlenameEn(filter.Employer.MiddleNameEn)
                .WithFirstnameRu(filter.Employer.FirstNameRu)
                .WithSurnameRu(filter.Employer.SurNameRu)
                .WithMiddlenameRu(filter.Employer.MiddleNameRu)
                .WithMobileNumber(filter.Employer.MobileNumber);
            }
            if(filter.Country != null)
            {
                _builder = _builder.WithCountry(filter.Country.Id);
            }
            if(filter.Boolean != null)
            {
                _builder = _builder.WithBoolean(filter.Boolean.Id);
            }
            if(filter.Title != null)
            {
                _builder = _builder.WithTitle(filter.Title.Id);
            }
            if(filter.QS != null)
            {
                _builder = _builder.WithQS(filter.QS.Id);
            }
            if(filter.University != null)
            {
                _builder = _builder.WithUniversity(filter.University.Id);
            }
            return await _builder
                .WithEmpUniversity(filter.EmpUniversity)
                .WithPosition(filter.Position)
                .WithUnit(filter.Unit).GetResultAsync();
        }

        public override async Task CreateAsync(QSExpert model)
        {
            var document = _mapper.Map<QsExpertDocument>(model);
            
            var parsedUnivId = ObjectId.Parse(model.UniversityId);
            if (!await _context.Universities.Find(u => u.Id == parsedUnivId).AnyAsync())
            {
                throw new DocumentNotFoundException("University id invalid: Not found university by id " +
                                                    parsedUnivId);
            }
            document.University = new QsExpertUniversityDocument
            {
                ID = parsedUnivId
            };
            
            var parsedCountryId = ObjectId.Parse(model.CountryId);
            if (!await _context.Countries.Find(u => u.Id == parsedCountryId).AnyAsync())
            {
                throw new DocumentNotFoundException("Country id invalid: Not found country by id " +
                                                    parsedCountryId);
            }
            document.Country = new QsExpertCountryDocument { ID = parsedCountryId};
            
            var parsedTitleId = ObjectId.Parse(model.TitleId);
            if (!await _context.Titles.Find(u => u.Id == parsedTitleId).AnyAsync())
            {
                throw new DocumentNotFoundException("Title id invalid: Not found title by id " +
                                                    parsedTitleId);
            }
            document.Title = new QsExpertTitleDocument { ID = parsedTitleId};
            
            var parsedBooleanId = ObjectId.Parse(model.BooleanId);
            if (!await _context.Booleans.Find(u => u.Id == parsedBooleanId).AnyAsync())
            {
                throw new DocumentNotFoundException("Boolean id invalid: Not found boolean by id " +
                                                    parsedBooleanId);
            }
            document.Boolean = new QsExpertBooleanDocument { ID = parsedBooleanId};
            
            var parsedQsId = ObjectId.Parse(model.QsId);
            if (!await _context.QS.Find(u => u.Id == parsedQsId).AnyAsync())
            {
                throw new DocumentNotFoundException("QS id invalid: Not found qs by id " +
                                                    parsedQsId);
            }
            document.QS = new QsExpertQSDocument { ID = parsedQsId};
            if (await _context.QSExperts.Find(e =>
                e.Employer.Email == document.Employer.Email).AnyAsync())
            {
                throw new DocumentPresentException("Employer with this email exists");
            }
            document.Id = ObjectId.GenerateNewId();
            await _context.QSExperts.InsertOneAsync(document);
        }
    }
}
