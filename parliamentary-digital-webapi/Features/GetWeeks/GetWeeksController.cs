using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        public IActionResult GetWeeks()
        {
            return Ok(new GetWeeksViewModel(GetAllWeeks()));
        }

        private IEnumerable<WeekViewModel> GetAllWeeks()
        {
            return
                GetAllDatesForNumberWeeksToInclude()
                    .GroupBy(date => new
                    {
                        Year = date.Year,
                        WeekNo = GetWeekOfYear(date),
                        StartOfWeekDate = StartOfWeekDate(date, DayOfWeek.Sunday),
                        EndOfWeekDate = EndOfWeekDate(date, DayOfWeek.Sunday)
                    })
                    .Select(date => new WeekViewModel(date.Key.Year, date.Key.WeekNo, date.Key.StartOfWeekDate, date.Key.EndOfWeekDate, IsCurrentWeek(date.Key.StartOfWeekDate, date.Key.EndOfWeekDate)));
        }

        private bool IsCurrentWeek(DateTime startDate, DateTime endDate)
        {
            return _datetimeService.GetDate() >= startDate && _datetimeService.GetDate() < endDate;
        }
        
        private IEnumerable<DateTime> GetAllDatesForNumberWeeksToInclude()
        {
            var allDatesForNumberWeeksToInclude = new List<DateTime>();

            var daysInAWeek = 7;
            
            for (var date = _datetimeService.GetDate();
                date <= _datetimeService.GetDate().AddDays(daysInAWeek * _getWeeksSettings.NumberOfWeeksToInclude);
                date = date.AddDays(1))
                allDatesForNumberWeeksToInclude.Add(date);
            
            return allDatesForNumberWeeksToInclude;
        }

        private static DateTime EndOfWeekDate(DateTime dateTime, DayOfWeek startOfWeek)
        {
            return StartOfWeekDate(dateTime, startOfWeek).AddDays(6);
        }

        private static int GetWeekOfYear(DateTime date)
        {
            return
                CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date,
                CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule,
                CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
        }

        private static DateTime StartOfWeekDate(DateTime dateTime, DayOfWeek startOfWeek)
        {
            var diff = dateTime.DayOfWeek - startOfWeek;

            if (diff < 0) diff += 7;

            return dateTime.AddDays(-1 * diff).Date;
        }
    }
}