using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper.Internal;
using CURS.Domain.Dtos;
using CURS.Domain.Interfaces.Data;
using Microsoft.AspNetCore.Mvc;

namespace CURS.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProgrammesController : ControllerBase
    {
        private readonly IProgrammesRepository _repos;

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
                programmes.ForAll(s =>
                {
                    res.PivotData.AddLast(new List<object>
                    {
                        s.ID,
                        s.ATT_DISCIPLINE,
                        s.ATT_SPECIALITIES,
                        s.ATT_COURSES,
                        s.ATT_LANGUAGE_DEPARTMENTS,
                        s.ATT_TOTAL_CREDITS,
                        s.ATT_COUNT_OF_STUDENTS,
                        s.ATT_GROUPES,
                        s.ATT_SUBGROUPS,
                        s.ATT_TOTAL,
                        s.ATT_LESSON_TYPE,
                        "факт",
                        s.ATT_GROUP_CODE,
                        s.ATT_CONNECTION_CODE
                    });
                });
                return Ok(res);
            }
            catch (Exception)
            {
                throw;
                res.Error++;
                return StatusCode(500, res);
            }
        }
    }
}