using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Core.DTOs;
using TestApp.Core.Services.Interfaces;

namespace TestApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RepeatWordController : ControllerBase
    {
        private readonly IRepeatWordService _repeatWordService;
        public RepeatWordController(IRepeatWordService repeatWordService)
        {
            _repeatWordService = repeatWordService;
        }

        [HttpGet("")]
        public ActionResult Get(RepeatWordDTO repeatWordDto)
        {
            var response = _repeatWordService.Get(repeatWordDto);
            return Ok(response);
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll(RepeatWordDTO repeatWordDto)
        {
            var response = _repeatWordService.GetAll(repeatWordDto);
            return Ok(response);
        }
    }
}
