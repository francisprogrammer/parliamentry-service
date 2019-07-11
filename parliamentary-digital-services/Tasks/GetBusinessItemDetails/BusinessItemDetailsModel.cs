using System;
using System.Collections.Generic;

namespace PD.Services.Tasks.GetBusinessItemDetails
{
    public class BusinessItemDetailsModel
    {
        public int Id { get; }
        public DateTime StartDate { get; }
        public string StartTime { get; }
        public DateTime EndDate { get; }
        public string EndTime { get; }
        public string Description { get; }
        public string Category { get; }
        public IEnumerable<MemberItemViewModel> Members { get; }

        public BusinessItemDetailsModel(int id, DateTime startDate, string startTime, DateTime endDate, string endTime, string description, string category, IEnumerable<MemberItemViewModel> members)
        {
            Id = id;
            StartDate = startDate;
            StartTime = startTime;
            EndDate = endDate;
            EndTime = endTime;
            Description = description;
            Category = category;
            Members = members;
        }
    }
}