using AutoMapper;
using CURS.Domain.Core.Models;
using CURS.Domain.Dtos;
using CURS.Domain.Interfaces.Data;
using CURS.Infrastructure.Data.Contexts;
using CURS.Infrastructure.Data.Documents;
using CURS.Infrastructure.Data.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CURS.Infrastructure.Data.Repositories
{
    public class QSExpertsRepository : BaseRepository<QSExpert>, IQSExpertsRepository
    {
        private QSExpertFilterBuilder _builder;
        public QSExpertsRepository(MongoContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<QSExpertViewDto>> GetByFilter(QSExpertFilterDto filter)
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
    }
}
