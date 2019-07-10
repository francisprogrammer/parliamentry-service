using System;

namespace PD.WebApi.Features.GetWeeks
{
    public class WeekViewModel
    {
        public int Year { get; }
        public int WeekNo { get; }
        public DateTime StartOfWeek { get; }
        public DateTime EndOfWeek { get; }

        public WeekViewModel(int year, int weekNo, DateTime startOfWeek, DateTime endOfWeek)
        {
            Year = year;
            WeekNo = weekNo;
            StartOfWeek = startOfWeek;
            EndOfWeek = endOfWeek;
        }
    }
}