using CURS.Domain.Dtos;
using CURS.Infrastructure.Data.Contexts;
using CURS.Infrastructure.Data.Documents;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using System;
using CURS.Domain.Core.Models;
using MongoDB.Bson.Serialization;

namespace CURS.Infrastructure.Data.Utils
{
    internal class QSExpertFilterBuilder
    {
        private FilterDefinition<QsExpertDocument> _filterExp;
        private readonly MongoContext _context;
        private readonly IMapper _mapper;
        public QSExpertFilterBuilder(MongoContext context, IMapper mapper)
        {
            _filterExp = Builders<QsExpertDocument>.Filter.Empty;
            _context = context;
            _mapper = mapper;
        }
        public QSExpertFilterBuilder WithUniversity(string universityId)
        {
            if (!string.IsNullOrEmpty(universityId))
            {
                var parsedId =  ObjectId.Parse(universityId);
                _filterExp &= Builders<QsExpertDocument>.Filter.Eq("University.ID", parsedId);
            }
            return this;
        }

        public QSExpertFilterBuilder WithFirstnameRu(string firstnameRu)
        {
            if (!string.IsNullOrEmpty(firstnameRu))
            {
                _filterExp &= Builders<QsExpertDocument>.Filter.Eq("Employer.FirstNameRu", firstnameRu);
            }
            return this;
        }
        public QSExpertFilterBuilder WithSurnameRu(string surnameRu)
        {
            if (!string.IsNullOrEmpty(surnameRu))
            {
                _filterExp &= Builders<QsExpertDocument>.Filter.Eq("Employer.SurNameRu", surnameRu);
            }
            return this;
        }
        public QSExpertFilterBuilder WithMiddlenameRu(string middlenameRu)
        {
            if (!string.IsNullOrEmpty(middlenameRu))
            {
                _filterExp &= Builders<QsExpertDocument>.Filter.Eq("Employer.MiddleNameRu", middlenameRu);
            }
            return this;
        }
        public QSExpertFilterBuilder WithFirstnameEn(string firstnameEn)
        {
            if (!string.IsNullOrEmpty(firstnameEn))
            {
                _filterExp &= Builders<QsExpertDocument>.Filter.Eq("Employer.FirstNameEn", firstnameEn);
            }
            return this;
        }
        public QSExpertFilterBuilder WithSurnameEn(string surnameEn)
        {
            if (!string.IsNullOrEmpty(surnameEn))
            {
                _filterExp &= Builders<QsExpertDocument>.Filter.Eq("Employer.SurNameEn", surnameEn);
            }
            return this;
        }
        public QSExpertFilterBuilder WithMiddlenameEn(string middlenameEn)
        {
            if (!string.IsNullOrEmpty(middlenameEn))
            {
                _filterExp &= Builders<QsExpertDocument>.Filter.Eq("Employer.MiddleNameEn", middlenameEn);
            }
            return this;
        }

        public QSExpertFilterBuilder WithCountry(string countryId)
        {
            if (!string.IsNullOrEmpty(countryId))
            {
                var parsedId = ObjectId.Parse(countryId);
                _filterExp &= Builders<QsExpertDocument>.Filter.Eq("Country.ID", parsedId);
            }
            return this;
        }

        public QSExpertFilterBuilder WithEmpUniversity(string empUniversity)
        {
            if (!string.IsNullOrEmpty(empUniversity))
            {
                _filterExp &= Builders<QsExpertDocument>.Filter.Eq("EmpUniversity", empUniversity);
            }
            return this;
        }
        public QSExpertFilterBuilder WithUnit(string unit)
        {
            if (!string.IsNullOrEmpty(unit))
            {
                _filterExp &= Builders<QsExpertDocument>.Filter.Eq("Unit", unit);
            }
            return this;
        }
        public QSExpertFilterBuilder WithPosition(string position)
        {
            if (!string.IsNullOrEmpty(position))
            {
                _filterExp &= Builders<QsExpertDocument>.Filter.Eq("Position", position);
            }
            return this;
        }
        public QSExpertFilterBuilder WithTitle(string titleId)
        {
            if (!string.IsNullOrEmpty(titleId))
            {
                var parsedId = ObjectId.Parse(titleId);
                _filterExp &= Builders<QsExpertDocument>.Filter.Eq("Title.ID", parsedId);
            }
            return this;
        }

        public QSExpertFilterBuilder WithBirthDate(DateTime date)
        {
            if (date != default)
            {
                var tomorrow = date.AddDays(1);
                _filterExp &= Builders<QsExpertDocument>.Filter.Where(u =>
                u.Employer.BirthDate >= date && u.Employer.BirthDate < tomorrow);
            }
            return this;
        }

        public QSExpertFilterBuilder WithMobileNumber(string number)
        {
            if (!string.IsNullOrEmpty(number))
            {
                _filterExp &= Builders<QsExpertDocument>.Filter.Eq("Employer.MobileNumber", number);
            }
            return this;
        }

        public QSExpertFilterBuilder WithEmail(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                _filterExp &= Builders<QsExpertDocument>.Filter.Eq("Employer.Email", email);
            }
            return this;
        }
        public QSExpertFilterBuilder WithBoolean(string booleanId)
        {
            if (!string.IsNullOrEmpty(booleanId))
            {
                var parsedId = ObjectId.Parse(booleanId);
                _filterExp &= Builders<QsExpertDocument>.Filter.Eq("Boolean.ID", parsedId);
            }
            return this;
        }

        public QSExpertFilterBuilder WithQS(string qsId)
        {
            if (!string.IsNullOrEmpty(qsId))
            {
                var parsedId = ObjectId.Parse(qsId);
                _filterExp &= Builders<QsExpertDocument>.Filter.Eq("QS.ID", parsedId);
            }
            return this;
        }
        public async Task<IReadOnlyCollection<QSExpertViewDto>> GetResultAsync()
        {
           var experts = await _context.QSExperts.Aggregate().Match(_filterExp)
                      .Lookup<UniversityDocument, QSExpertViewDocument>("Copy_of_DirUniversities", "University.ID", "_id", "University")
                      .Unwind<QSExpertViewDocument, QSExpertViewDocument>(c => c.University)
                      .Lookup<TitleDocument, QSExpertViewDocument>("DirTitle", "Title.ID", "_id", "Title")
                      .Unwind<QSExpertViewDocument, QSExpertViewDocument>(c => c.Title)
                      .Lookup<CountryDocument, QSExpertViewDocument>("DirCountry", "Country.ID", "_id", "Country")
                      .Unwind<QSExpertViewDocument, QSExpertViewDocument>(c => c.Country)
                      .Lookup<BooleanDocument, QSExpertViewDocument>("DirBoolean", "Boolean.ID", "_id", "Boolean")
                      .Unwind<QSExpertViewDocument, QSExpertViewDocument>(c => c.Boolean)
                      .Lookup<QSDocument, QSExpertViewDocument>("DirQS", "QS.ID", "_id", "QS")
                      .Unwind<QSExpertViewDocument, QSExpertViewDocument>(c => c.QS)
                      .Project(Builders<QSExpertViewDocument>.Projection.Expression(q =>
                      new QSExpertViewDto
                      {
                          University = _mapper.Map<NameDto>(q.University.Name),
                          FIORu = q.Employer.SurNameRu + " " + q.Employer.FirstNameRu + " " + q.Employer.MiddleNameRu,
                          FIOEn = q.Employer.SurNameEn + " " + q.Employer.FirstNameEn + " " + q.Employer.MiddleNameEn,
                          Country = _mapper.Map<NameDto>(q.Country.Name),
                          EmpUniversity = q.EmpUniversity,
                          Unit = q.Unit,
                          Position = q.Position,
                          Title = _mapper.Map<NameDto>(q.Title.Name),
                          BirthDate = q.Employer.BirthDate,
                          MobileNumber = q.Employer.MobileNumber,
                          Email = q.Employer.Email,
                          Boolean = _mapper.Map<NameDto>(q.Boolean.Name),
                          QS = _mapper.Map<NameDto>(q.QS.Name)
                      })).ToListAsync();
            return experts;
        }
    }
}
