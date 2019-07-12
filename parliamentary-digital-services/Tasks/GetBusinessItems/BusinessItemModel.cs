using System;

namespace PD.Services.Tasks.GetBusinessItems
{
    public class BusinessItemModel
    {
        public int Id { get; }

        public string StartDate { get; }

        public string StartTime { get; }

        public string EndDate { get; }

        public string EndTime { get; }

        public string Description { get; }

        public BusinessItemModel(int id, string startDate, string startTime, string endDate, string endTime, string description)
        {
            Id = id;
            StartDate = startDate;
            StartTime = startTime;
            EndDate = endDate;
            EndTime = endTime;
            Description = description;
        }
    }
}