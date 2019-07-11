using System.Collections.Generic;
using PD.Services.Common;

namespace PD.Services.Tasks.GetBusinessItems
{
    public class GetBusinessItemBetweenDatesResponse : Response
    {
        public IEnumerable<BusinessItemModel> BusinessItems { get; }
        
        public GetBusinessItemBetweenDatesResponse(bool isSuccess, IEnumerable<BusinessItemModel> businessItems) : base(isSuccess)
        {
            BusinessItems = businessItems;
        }
    }
}