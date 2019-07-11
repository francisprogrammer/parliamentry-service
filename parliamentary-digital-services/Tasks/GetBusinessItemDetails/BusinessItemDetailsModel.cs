using System;
using System.Collections.Generic;

namespace PD.Services.Tasks.GetBusinessItemDetails
{
    public class BusinessItemDetailsModel
    {
        public DateTime StartDateAndTime { get; }
        public DateTime EndDateAndTime { get; }
        public string Description { get; }
        public string Category { get; }
        public IEnumerable<MemberItemViewModel> Members { get; }

        public BusinessItemDetailsModel(DateTime startDateAndTime, DateTime endDateAndTime, string description,
            string category, IEnumerable<MemberItemViewModel> members)
        {
            StartDateAndTime = startDateAndTime;
            EndDateAndTime = endDateAndTime;
            Description = description;
            Category = category;
            Members = members;
        }
    }
}