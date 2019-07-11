using System.Collections.Generic;
using PD.Services.Common;

namespace PD.Services.Tasks.GetBusinessItems
{
    public class GetBusinessItemBetweenDatesResponse : Response
    {
        public IEnumerable<BusinessItemModel> BusinessItems { get; }
        
        private GetBusinessItemBetweenDatesResponse(bool isSuccess, string message, IEnumerable<BusinessItemModel> businessItems) : base(isSuccess, message)
        {
            BusinessItems = businessItems;
        }

        public static GetBusinessItemBetweenDatesResponse Failed(string errorMessage)
        {
            return new GetBusinessItemBetweenDatesResponse(false, errorMessage, null);
        }

        public static GetBusinessItemBetweenDatesResponse Success(IEnumerable<BusinessItemModel> @businessItemModels)
        {
            return new GetBusinessItemBetweenDatesResponse(true, string.Empty, businessItemModels);
        }
    }
}   