using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
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
        private FactCalculator calc;
        public ProgrammesController(IProgrammesRepository repos)
        {
            _repos = repos;
            calc = new FactCalculator();
        }

        [HttpGet]
        public async Task<IActionResult> GetProgrammes()
        {
            ProgrammesListDto res;
            try
            {
                var programmes = await _repos.GetAllAsync(); 
                res = new ProgrammesListDto(programmes.Count);
                var set = new List<List<object>>();
                programmes.ForAll(g =>
                {
                    string id = g.Programmes.Take(g.Programmes.Count() - 1).Aggregate("[", (current, s) => current + $@"""{s.ID}"",");
                    id += $@"""{g.Programmes.Last().ID}""]";
                    foreach (var s in g.Programmes)
                    {
                        s.ATT_RELATION = g.RelationKey;
                        s.ATT_TOTAL = calc.FactsSum(s.ATT_PRACTICE_FACT, s.ATT_LABORATORY_FACT,
                            s.ATT_LECTURE_FACT,
                            s.ATT_SRSP_FACT,
                            s.ATT_STUDY_PRACTICE, s.ATT_PROD_PRACTICE, s.ATT_PED_PRACTICE, s.ATT_DIPLOMA_PRACTICE,
                            s.ATT_RESEARCH_PRACTICE, s.ATT_LANGUAGE_PRACTICE, s.ATT_DIPLOMA_WORK, s.ATT_DISSERTATION,
                            s.ATT_GOS,
                            s.ATT_OTHER);
                        set.Add(new List<object>
                        {
                            id,
                            s.ATT_DISCIPLINE,
                            s.ATT_SPECIALITIES,
                            s.ATT_COURSES,
                            s.ATT_LANGUAGE_DEPARTMENTS,
                            s.ATT_TOTAL_CREDITS,
                            s.ATT_COUNT_OF_STUDENTS,
                            s.ATT_GROUPS.Split(" / ").Length,
                            s.ATT_SUBGROUPS,
                            s.ATT_TOTAL,
                            s.ATT_LESSON_TYPE,
                            "факт",
                            s.ATT_GROUP_CODE,
                            s.ATT_CONNECTION_CODE,
                        });
                    }
                    calc.Reset();
                });
                res.PivotData = set;
                return Ok(res);
            }
            catch
            {
                throw;
                res = new ProgrammesListDto();
                res.Error++;
                return StatusCode(500, res);
            }
        }

    }
}