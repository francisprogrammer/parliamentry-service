using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Extensions.Options;
using PD.Domain;
using PD.Services.Common;
using PD.Services.Tasks.GetDateAndTime;

namespace PD.Services.Tasks.GetWeeks
{
    public class GetWeeksService : IGetWeeks
    {
        private readonly IDateTimeService _datetimeService;
        private readonly GetWeekSettings _getWeeksSettings;

        public GetWeeksService(
            IDateTimeService datetimeService,
            IOptions<GetWeekSettings> getWeeksSettings)
        {
            _datetimeService = datetimeService;
            _getWeeksSettings = getWeeksSettings.Value;
        }

        public GetWeeksResponse GetWeeks()
        {
            var weekViewModels =
                CreateWeeks()
                    .Select(week => new WeekViewModel(week.Year, week.WeekNo, week.StartOfWeek.ToString("dd-MM-yyyy"), week.EndOfWeek.ToString("dd-MM-yyyy"), week.IsCurrentWeek));

            return new GetWeeksResponse(new GetWeeksViewModel(weekViewModels));
        }

        private IEnumerable<Week> CreateWeeks()
        {
            return
                GetAllDatesForNumberWeeksToInclude()
                    .GroupBy(date => new
                    {
                        Year = date.Year,
                        WeekNo = GetWeekOfYear(date),
                        StartOfWeekDate = StartOfWeekDate(date, DayOfWeek.Monday),
                        EndOfWeekDate = EndOfWeekDate(date, DayOfWeek.Monday)
                    })
                    .Select(date => new Week(date.Key.Year, date.Key.WeekNo, date.Key.StartOfWeekDate, date.Key.EndOfWeekDate, IsCurrentWeek(date.Key.StartOfWeekDate, date.Key.EndOfWeekDate)));
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
            var cultureInfo = new CultureInfo("en-GB");
            
            return
                cultureInfo.Calendar.GetWeekOfYear(date,
                    cultureInfo.DateTimeFormat.CalendarWeekRule,
                DayOfWeek.Monday);
        }

        private static DateTime StartOfWeekDate(DateTime dateTime, DayOfWeek startOfWeek)
        {
            var diff = dateTime.DayOfWeek - startOfWeek;

            if (diff < 0) diff += 7;

            return dateTime.AddDays(-1 * diff).Date;
        }
    }
}