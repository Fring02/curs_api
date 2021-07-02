using System.Threading.Tasks;
using CURS.Domain.Dtos;
using CURS.Domain.Interfaces.Data;
using Microsoft.AspNetCore.Mvc;

namespace CURS.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ViewSettingsController : ControllerBase
    {
        private IQsExpertFieldsRepository _repos;

        public ViewSettingsController(IQsExpertFieldsRepository repos)
        {
            _repos = repos;
        }
        [HttpGet]
        public async Task<IActionResult> GetByQsExpertFields([FromQuery] QsExpertFieldsFilterDto fieldsFilterDto)
        {
            return Ok(await _repos.GetByFields(fieldsFilterDto));
        }
    }
}