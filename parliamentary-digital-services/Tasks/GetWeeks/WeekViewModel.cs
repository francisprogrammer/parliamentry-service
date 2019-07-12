using System;

namespace PD.Services.Tasks.GetWeeks
{
    public class WeekViewModel
    {
        public int Year { get; }
        public int WeekNo { get; }
        public string StartOfWeek { get; }
        public string EndOfWeek { get; }
        public bool IsCurrentWeek { get; }

        public WeekViewModel(int year, int weekNo, string startOfWeek, string endOfWeek, bool isCurrentWeek)
        {
            Year = year;
            WeekNo = weekNo;
            StartOfWeek = startOfWeek;
            EndOfWeek = endOfWeek;
            IsCurrentWeek = isCurrentWeek;
        }
    }
}