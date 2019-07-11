using System.Collections.Generic;
using PD.Domain;

namespace PD.Services.Tasks.GetBusinessItemDetails
{
    public class GetParliamentEventDetailsResponse
    {
        public BusinessItemDetails BusinessItemDetails { get; }

        public GetParliamentEventDetailsResponse(BusinessItemDetails businessItemDetails)
        {
            BusinessItemDetails = businessItemDetails;
        }
    }
}