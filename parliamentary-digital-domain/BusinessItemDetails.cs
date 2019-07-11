using System;
using System.Collections.Generic;

namespace PD.Domain
{
    public class BusinessItemDetails
    {
        public DateTime StartDateAndTime { get; }
        public DateTime EndDateAndTime { get; }
        public string Description { get; }
        public string Category { get; }
        public IEnumerable<MemberItem> Members { get; }

        public BusinessItemDetails(DateTime startDateAndTime, DateTime endDateAndTime, string description, string category, IEnumerable<MemberItem> members)
        {
            StartDateAndTime = startDateAndTime;
            EndDateAndTime = endDateAndTime;
            Description = description;
            Category = category;
            Members = members;
        }
    }
}