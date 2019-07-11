using System;

namespace PD.Services.Tasks.GetBusinessItems
{
    public class BusinessItemModel
    {
        public DateTime StartDateAndTime { get; }
        public DateTime EndDateAndTime { get; }
        public string Description { get; }

        public BusinessItemModel(DateTime startDateAndTime, DateTime endDateAndTime, string description)
        {
            StartDateAndTime = startDateAndTime;
            EndDateAndTime = endDateAndTime;
            Description = description;
        }
    }
}