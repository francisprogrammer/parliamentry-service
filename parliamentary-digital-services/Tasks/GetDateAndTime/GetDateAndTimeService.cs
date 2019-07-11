using System;

namespace PD.Services.Tasks.GetDateAndTime
{
    public class GetDateAndTimeService : IDateTimeService
    {
        public DateTime GetDate()
        {
            return DateTime.UtcNow;
        }
    }
}