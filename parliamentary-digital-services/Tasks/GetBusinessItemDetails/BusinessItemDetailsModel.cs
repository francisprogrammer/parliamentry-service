using System;
using System.Collections.Generic;

namespace PD.Services.Tasks.GetBusinessItemDetails
{
    public class BusinessItemDetailsModel
    {
        public int Id { get; }
        public string StartDate { get; }
        public string StartTime { get; }
        public string EndDate { get; }
        public string EndTime { get; }
        public string Description { get; }
        public string Category { get; }
        public IEnumerable<MemberItemViewModel> Members { get; }

        public BusinessItemDetailsModel(int id, string startDate, string startTime, string endDate, string endTime, string description, string category, IEnumerable<MemberItemViewModel> members)
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