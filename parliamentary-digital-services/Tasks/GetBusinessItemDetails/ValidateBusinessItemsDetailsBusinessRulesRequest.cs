using System;

namespace PD.Services.Tasks.GetBusinessItemDetails
{
    public class ValidateBusinessItemsDetailsBusinessRulesRequest
    {
        public int Id { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public ValidateBusinessItemsDetailsBusinessRulesRequest(int id, DateTime startDate, DateTime endDate)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}