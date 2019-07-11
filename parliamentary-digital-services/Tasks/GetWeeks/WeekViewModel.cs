using System;

namespace PD.Services.Tasks.GetWeeks
{
    public class WeekViewModel
    {
        public int Year { get; }
        public int WeekNo { get; }
        public DateTime StartOfWeek { get; }
        public DateTime EndOfWeek { get; }
        public bool IsCurrentWeek { get; }

        public WeekViewModel(int year, int weekNo, DateTime startOfWeek, DateTime endOfWeek, bool isCurrentWeek)
        {
            Year = year;
            WeekNo = weekNo;
            StartOfWeek = startOfWeek;
            EndOfWeek = endOfWeek;
            IsCurrentWeek = isCurrentWeek;
        }
    }
}