using CURS.Domain.Dtos;
using CURS.Domain.Interfaces.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CURS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private IUniversitiesRepository<UniversityViewDto> _repos;

        public UniversitiesController(IUniversitiesRepository<UniversityViewDto> repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public async Task<IActionResult> GetUniversities(string name)
        {
            if (string.IsNullOrEmpty(name)) return BadRequest();
            var universities = await _repos.GetByFilter(name);
            return Ok(universities);
        }
    }
}
