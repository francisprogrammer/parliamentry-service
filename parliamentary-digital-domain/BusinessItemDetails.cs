using System;
using System.Collections.Generic;

namespace PD.Domain
{
    public class BusinessItemDetails
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public string EndTime { get; set; }
        public string Description { get; set; }
        public string Category { get; }
        public IEnumerable<MemberItem> Members { get; }

        public BusinessItemDetails(int id, DateTime startDate, string startTime, DateTime endDate, string endTime, string description, string category, IEnumerable<MemberItem> members)
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