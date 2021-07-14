using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using AutoMapper.QueryableExtensions;
using CURS.Domain.Core.Models;
using CURS.Domain.Dtos;
using CURS.Domain.Interfaces.Data;
using CURS.Infrastructure.Data.Contexts;
using CURS.Infrastructure.Data.Documents;
using CURS.Infrastructure.Data.Utils;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace CURS.Infrastructure.Data.Repositories
{
    public class ProgrammesRepository : BaseRepository<Programme, GrouppedProgrammesViewDto>, IProgrammesRepository
    {
        public ProgrammesRepository(MongoContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<IReadOnlyCollection<GrouppedProgrammesViewDto>> GetAllAsync()
        {
            return await _context.Programmes.Aggregate()
                .Group(s => s.ATT_RELATION, grouping =>
                    new GrouppedProgrammesViewDto()
                {
                    RelationKey = grouping.Key,
                    Programmes = grouping.Select(s => new ProgrammeViewDto
                    {
                        ID = s.ID,
                        ATT_DISCIPLINE = s.ATT_DISCIPLINE,
                        ATT_GROUPS = s.ATT_GROUPS,
                        ATT_LANGUAGE_DEPARTMENTS = s.ATT_LANGUAGE_DEPARTMENTS,
                        ATT_SPECIALITIES = s.ATT_SPECIALITIES,
                        ATT_LESSON_TYPE = s.ATT_LESSON_TYPE,
                        ATT_COUNT_OF_STUDENTS = s.ATT_COUNT_OF_STUDENTS,
                        ATT_TOTAL_CREDITS = s.ATT_TOTAL_CREDITS,
                        ATT_LECTURE_FACT = s.ATT_LECTURE_FACT,
                        ATT_PRACTICE_FACT = s.ATT_PRACTICE_FACT,
                        ATT_LABORATORY_FACT = s.ATT_LABORATORY_FACT,
                        ATT_SRSP_FACT = s.ATT_SRSP_FACT,
                        ATT_STUDY_PRACTICE = s.ATT_STUDY_PRACTICE,
                        ATT_PROD_PRACTICE = s.ATT_PROD_PRACTICE,
                        ATT_PED_PRACTICE = s.ATT_PED_PRACTICE,
                        ATT_DIPLOMA_PRACTICE = s.ATT_DIPLOMA_PRACTICE,
                        ATT_RESEARCH_PRACTICE = s.ATT_RESEARCH_PRACTICE,
                        ATT_LANGUAGE_PRACTICE = s.ATT_LANGUAGE_PRACTICE,
                        ATT_DIPLOMA_WORK = s.ATT_DIPLOMA_WORK,
                        ATT_DISSERTATION = s.ATT_DISSERTATION,
                        ATT_GOS = s.ATT_GOS,
                        ATT_OTHER = s.ATT_OTHER,
                        ATT_COURSES = s.ATT_COURSES,
                        ATT_SUBGROUPS = s.ATT_SUBGROUPS,
                        ATT_GROUP_CODE = s.ATT_GROUP_CODE,
                        ATT_CONNECTION_CODE = s.ATT_CONNECTION_CODE
                    })
                })
                .ToListAsync();
        }
        public override Task CreateAsync(Programme model)
        {
            throw new NotImplementedException();
        }
    }
}