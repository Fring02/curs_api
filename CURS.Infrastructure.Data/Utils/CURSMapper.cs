using AutoMapper;
using CURS.Domain.Core.Models;
using CURS.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using CURS.Domain.Dtos.Create;
using CURS.Infrastructure.Data.Documents;

namespace CURS.Infrastructure.Data.Utils
{
    public class CURSMapper : Profile
    {
        public CURSMapper()
        {
            CreateMap<Name, NameDto>();
            CreateMap<QSExpertCreateDto, QSExpert>();
            CreateMap<EmployerCreateDto, Employer>();
            CreateMap<QSExpert, QSExpertViewDocument>();
            CreateMap<QSExpert, QsExpertDocument>();
        }
    }
}
