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
    public class QSExpertsController : ControllerBase
    {

        private IQSExpertsRepository _repos;

        public QSExpertsController(IQSExpertsRepository repos)
        {
            _repos = repos;
        }


        [HttpGet]
        public async Task<IActionResult> GetExperts([FromQuery] QSExpertFilterDto filter)
        {
            return Ok(await _repos.GetByFilter(filter));
        }
    }
}
