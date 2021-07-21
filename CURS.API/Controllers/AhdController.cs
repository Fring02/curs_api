using System;
using System.Threading.Tasks;
using CURS.Domain.Interfaces.Data;
using Microsoft.AspNetCore.Mvc;

namespace CURS.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class AhdController : ControllerBase
    {
        private IAhdRepository _repos;

        public AhdController(IAhdRepository repos)
        {
            _repos = repos;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateStudentsByTranscriptFaculty()
        {
            try
            {
                await _repos.CalculateStudentsWithTranscript();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}