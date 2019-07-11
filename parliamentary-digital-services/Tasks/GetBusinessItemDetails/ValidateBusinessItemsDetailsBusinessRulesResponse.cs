using System.Collections.Generic;
using PD.Services.Common;

namespace PD.Services.Tasks.GetBusinessItemDetails
{
    public class ValidateBusinessItemsDetailsBusinessRulesResponse : Response
    {
        private ValidateBusinessItemsDetailsBusinessRulesResponse(bool isSuccess, IEnumerable<string> errorMessageses) : base(isSuccess, errorMessageses)
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