using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper.Internal;
using CURS.Domain.Dtos;
using CURS.Domain.Interfaces.Data;
using CURS.Infrastructure.Data.Utils;
using Microsoft.AspNetCore.Mvc;

namespace CURS.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProgrammesController : ControllerBase
    {
        private readonly IProgrammesRepository _repos;
        private readonly Lazy<FactCalculator> _calc = new Lazy<FactCalculator>();
        public ProgrammesController(IProgrammesRepository repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public async Task<IActionResult> GetProgrammes()
        {
            var res = new ProgrammesListDto();
            try
            {
                var programmes = await _repos.GetAllAsync();
                programmes.ForAll(g =>
                {
                    _calc.Value.Reset();
                    foreach (var s in g.Programmes)
                    {
                        s.ATT_RELATION = g.RelationKey;
                        s.ATT_TOTAL = _calc.Value.FactsSum(s.ATT_PRACTICE_FACT, s.ATT_LABORATORY_FACT,
                            s.ATT_LECTURE_FACT,
                            s.ATT_SRSP_FACT,
                            s.ATT_STUDY_PRACTICE, s.ATT_PROD_PRACTICE, s.ATT_PED_PRACTICE, s.ATT_DIPLOMA_PRACTICE,
                            s.ATT_RESEARCH_PRACTICE, s.ATT_LANGUAGE_PRACTICE, s.ATT_DIPLOMA_WORK, s.ATT_DISSERTATION,
                            s.ATT_GOS,
                            s.ATT_OTHER);
                        res.PivotData.AddLast(new List<object>
                        {
                            s.ID,
                            s.ATT_DISCIPLINE,
                            s.ATT_SPECIALITIES,
                            s.ATT_COURSES,
                            s.ATT_LANGUAGE_DEPARTMENTS,
                            s.ATT_TOTAL_CREDITS,
                            s.ATT_COUNT_OF_STUDENTS,
                            s.ATT_GROUPS,
                            s.ATT_SUBGROUPS,
                            s.ATT_TOTAL,
                            s.ATT_LESSON_TYPE,
                            "факт",
                            s.ATT_GROUP_CODE,
                            s.ATT_CONNECTION_CODE,
                            s.ATT_RELATION
                        });
                    }
                });
                return Ok(res);
            }
            catch
            {
                throw;
                res.Error++;
                return StatusCode(500, res);
            }
        }
    }
}