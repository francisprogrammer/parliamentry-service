using System.Collections.Generic;

namespace PD.Services.Tasks.GetBusinessItemDetails
{
    public class GetBusinessItemDetailsResponse
    {
        public BusinessItemDetailsModel BusinessItemDetailsModel { get; }

        public GetBusinessItemDetailsResponse(BusinessItemDetailsModel businessItemDetailsModel)
        {
            BusinessItemDetailsModel = businessItemDetailsModel;
        }
    }
}