using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PD.WebApi.Common;

namespace PD.WebApi.Features.GetWeeks
{
    public class GetWeeksController : ControllerBase
    {
        private readonly IDateTimeService _datetimeService;
        private readonly GetWeekSettings _getWeeksSettings;

        public GetWeeksController(
            IDateTimeService datetimeService,
            IOptions<GetWeekSettings> getWeeksSettings)
        {
            _datetimeService = datetimeService;
            _getWeeksSettings = getWeeksSettings.Value;
        }
        
        [Route("weeks")]
        public async Task<IActionResult> GetWeeks()
        {
            var weeks = new List<WeekViewModel>
            {
                new WeekViewModel(2019, 1, new DateTime(2019, 1, 1).Date, new DateTime(2019, 1, 7).Date)
            };

            return Ok(new GetWeeksViewModel(weeks));
        }
    }
}