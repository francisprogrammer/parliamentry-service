using System;

namespace PD.Domain
{
    public class Event
    {
        public DateTime StartDateAndTime { get; }
        public DateTime EndDateAndTime { get; }
        public string Description { get; }

        public Event(DateTime startDateAndTime, DateTime endDateAndTime, string description)
        {
            StartDateAndTime = startDateAndTime;
            EndDateAndTime = endDateAndTime;
            Description = description;
        }
    }
}