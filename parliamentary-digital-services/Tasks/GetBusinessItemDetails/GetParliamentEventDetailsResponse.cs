using System.Collections.Generic;
using PD.Domain;
using PD.Services.Common;

namespace PD.Services.Tasks.GetBusinessItemDetails
{
    public class GetParliamentEventDetailsResponse : Response
    {
        public BusinessItemDetails BusinessItemDetails { get; }

        public static GetParliamentEventDetailsResponse Failed()
        {
            return new GetParliamentEventDetailsResponse(false, null, new List<string>());
        }

        private GetParliamentEventDetailsResponse(bool isSuccess, BusinessItemDetails businessItemDetails, IEnumerable<string> errorMessages) : base(isSuccess, errorMessages)
        {
            BusinessItemDetails = businessItemDetails;
        }

        public static GetParliamentEventDetailsResponse Success(BusinessItemDetails businessItemDetails)
        {
            return new GetParliamentEventDetailsResponse(true, businessItemDetails, new List<string>());
        }
    }
}