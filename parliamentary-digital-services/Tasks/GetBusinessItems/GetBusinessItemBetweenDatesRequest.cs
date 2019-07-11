using System;

namespace PD.Services.Tasks.GetBusinessItems
{
    public class GetBusinessItemBetweenDatesRequest
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public GetBusinessItemBetweenDatesRequest(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}