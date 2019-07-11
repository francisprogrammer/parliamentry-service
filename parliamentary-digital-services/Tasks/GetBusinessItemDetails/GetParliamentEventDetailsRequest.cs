using System;

namespace PD.Services.Tasks.GetBusinessItemDetails
{
    public class GetParliamentEventDetailsRequest
    {
        public string Url { get; }
        public int Id { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public GetParliamentEventDetailsRequest(string url, int id, DateTime startDate, DateTime endDate)
        {
            Url = url;
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}