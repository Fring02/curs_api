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
        private readonly Lazy<FactCalculator> _calc = new Lazy<FactCalculator>();
        public CURSMapper()
        {
            CreateMap<Name, NameDto>();
            CreateMap<QSExpertCreateDto, QSExpert>();
            CreateMap<EmployerCreateDto, Employer>();
            CreateMap<QSExpert, QSExpertViewDocument>();
            CreateMap<QSExpert, QsExpertDocument>();
            CreateMap<ProgrammeDocument, ProgrammeViewDto>()
                .ForMember(s => s.ATT_TOTAL,
                o => o.MapFrom(s =>
                    _calc.Value.FactsSum(s.ATT_PRACTICE_FACT, s.ATT_LABORATORY_FACT, s.ATT_LECTURE_FACT,
                        s.ATT_SRSP_FACT,
                        s.ATT_STUDY_PRACTICE, s.ATT_PROD_PRACTICE, s.ATT_PED_PRACTICE, s.ATT_DIPLOMA_PRACTICE,
                        s.ATT_RESEARCH_PRACTICE, s.ATT_LANGUAGE_PRACTICE, s.ATT_DIPLOMA_WORK, s.ATT_DISSERTATION,
                        s.ATT_GOS,
                        s.ATT_OTHER))).ForMember(s => s.ATT_COURSES, o =>
                o.MapFrom(s => s.ATT_COURSES.ToString()));
        }
        
        
    }
}
