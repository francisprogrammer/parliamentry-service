using System.Collections.Generic;
using PD.Services.Common;

namespace PD.Services.Tasks.GetBusinessItems
{
    public class GetBusinessItemBetweenDatesResponse : Response
    {
        public IEnumerable<BusinessItemModel> BusinessItems { get; }

        private GetBusinessItemBetweenDatesResponse(bool isSuccess, IEnumerable<string> messages, IEnumerable<BusinessItemModel> businessItems) : base(isSuccess, messages)
        {
            BusinessItems = businessItems;
        }

        public static GetBusinessItemBetweenDatesResponse Failed(IEnumerable<string> errorMessages)
        {
            return new GetBusinessItemBetweenDatesResponse(false, errorMessages, null);
        }

        public static GetBusinessItemBetweenDatesResponse Success(IEnumerable<BusinessItemModel> @businessItemModels)
        {
            return new GetBusinessItemBetweenDatesResponse(true, null, businessItemModels);
        }
    }
}