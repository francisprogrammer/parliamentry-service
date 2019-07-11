using System;

namespace PD.Domain
{
    public class Week
    {
        public int Year { get; }
        public int WeekNo { get; }
        public DateTime StartOfWeek { get; }
        public DateTime EndOfWeek { get; }
        public bool IsCurrentWeek { get; }

        public Week(int year, int weekNo, DateTime startOfWeek, DateTime endOfWeek, bool isCurrentWeek)
        {
            Year = year;
            WeekNo = weekNo;
            StartOfWeek = startOfWeek;
            EndOfWeek = endOfWeek;
            IsCurrentWeek = isCurrentWeek;
        }
    }
}