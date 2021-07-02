using CURS.Domain.Dtos;
using CURS.Domain.Interfaces.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CURS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private readonly IUniversitiesRepository _repos;

        public UniversitiesController(IUniversitiesRepository repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public async Task<IActionResult> GetUniversities([FromQuery] UniversityFilterDto filter)
        {
            if (filter == null) return BadRequest();
            var universities = await _repos.GetByFilter(filter);
            return Ok(universities);
        }
    }
}
