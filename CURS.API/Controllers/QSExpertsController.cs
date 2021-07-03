using CURS.Domain.Dtos;
using CURS.Domain.Interfaces.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using AutoMapper;
using CURS.Domain.Core.Exceptions;
using CURS.Domain.Core.Models;
using CURS.Domain.Dtos.Create;
using CURS.Domain.Dtos.Filter;

namespace CURS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QSExpertsController : ControllerBase
    {

        private readonly IQSExpertsRepository _repos;
        private readonly IMapper _mapper;
        public QSExpertsController(IQSExpertsRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetExperts([FromQuery] QSExpertFilterDto filter)
        {
            return Ok(await _repos.GetByFilter(filter));
        }


        [HttpPost]
        public async Task<IActionResult> CreateExpert([FromBody] QSExpertCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.First().Errors[0].ErrorMessage;
                return BadRequest(error);
            }

            try
            {
                var address = new MailAddress(dto.Employer.Email).Address;
                var model = _mapper.Map<QSExpert>(dto);
                model.Employer.Email = address;
                await _repos.CreateAsync(model);
                return Ok("Created new QS expert");
            }
            catch (FormatException e)
            {
                return BadRequest(e.Message);
            }
            catch (DocumentNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (DocumentPresentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
