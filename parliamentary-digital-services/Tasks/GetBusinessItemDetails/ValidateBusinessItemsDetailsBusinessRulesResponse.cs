using System.Collections.Generic;
using PD.Services.Common;

namespace PD.Services.Tasks.GetBusinessItemDetails
{
    public class ValidateBusinessItemsDetailsBusinessRulesResponse : Response
    {
        private ValidateBusinessItemsDetailsBusinessRulesResponse(bool isSuccess, IEnumerable<string> errorMessages) : base(isSuccess, errorMessages)
        {
        }

        public static ValidateBusinessItemsDetailsBusinessRulesResponse Failed(IEnumerable<string> violations)
        {
            return new ValidateBusinessItemsDetailsBusinessRulesResponse(false, violations);
        }

        public static ValidateBusinessItemsDetailsBusinessRulesResponse Success()
        {
            return new ValidateBusinessItemsDetailsBusinessRulesResponse(true, null);
        }
    }
}