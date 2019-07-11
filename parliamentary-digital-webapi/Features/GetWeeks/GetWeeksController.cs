using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PD.Services.Tasks.GetWeeks;

namespace PD.WebApi.Features.GetWeeks
{
    public class GetWeeksController : ControllerBase
    {
        private readonly IGetWeeks _getWeeks;

        public GetWeeksController(IGetWeeks getWeeks)
        {
            _getWeeks = getWeeks;
        }

        [HttpGet]
        [Route("weeks")]
        public IActionResult GetWeeks()
        {
            var response = _getWeeks.GetWeeks();
            return Ok(response.GetWeeksViewModel);
        }
    }
}