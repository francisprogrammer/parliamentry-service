using System;

namespace PD.Services.Tasks.GetBusinessItems
{
    public class GetParliamentEventsRequest
    {
        public string Url { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public GetParliamentEventsRequest(string url, DateTime startDate, DateTime endDate)
        {
            Url = url;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}