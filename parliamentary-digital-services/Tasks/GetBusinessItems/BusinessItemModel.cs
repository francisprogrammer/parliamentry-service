using System;

namespace PD.Services.Tasks.GetBusinessItems
{
    public class BusinessItemModel
    {
        public int Id { get; }

        public DateTime StartDate { get; }

        public string StartTime { get; }

        public DateTime EndDate { get; }

        public string EndTime { get; }

        public string Description { get; }

        public BusinessItemModel(int id, DateTime startDate, string startTime, DateTime endDate, string endTime, string description)
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