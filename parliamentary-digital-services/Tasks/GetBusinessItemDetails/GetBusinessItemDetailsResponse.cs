using System.Collections.Generic;
using PD.Services.Common;

namespace PD.Services.Tasks.GetBusinessItemDetails
{
    public class GetBusinessItemDetailsResponse : Response
    {
        public BusinessItemDetailsModel BusinessItemDetailsModel { get; }

        private GetBusinessItemDetailsResponse(bool isSuccess, BusinessItemDetailsModel businessItemDetailsModel, IEnumerable<string> errorMessages) : base(isSuccess, errorMessages)
        {
            BusinessItemDetailsModel = businessItemDetailsModel;
        }

        public static GetBusinessItemDetailsResponse Failed(IEnumerable<string> errorMessageses)
        {
            return new GetBusinessItemDetailsResponse(false, null, errorMessageses);
        }

        public static GetBusinessItemDetailsResponse Success(BusinessItemDetailsModel businessItemDetailsModel)
        {
            return new GetBusinessItemDetailsResponse(true, businessItemDetailsModel, null);
        }
    }
}