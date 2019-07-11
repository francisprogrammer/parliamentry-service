using System;

namespace PD.Services.Tasks.GetBusinessItems
{
    public class ValidateBusinessItemsBusinessRulesRequest
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public ValidateBusinessItemsBusinessRulesRequest(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}