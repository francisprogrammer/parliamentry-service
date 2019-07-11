using System.Collections.Generic;
using System.Linq;
using PD.Services.Common;

namespace PD.Services.Tasks.GetBusinessItems
{
    public class ValidateBusinessItemsBusinessRulesResponse : Response
    {
        private ValidateBusinessItemsBusinessRulesResponse(bool isSuccess, IEnumerable<string> messages) : base(isSuccess, messages)
        {
        }

        public static ValidateBusinessItemsBusinessRulesResponse Failed(IEnumerable<string> violations)
        {
            return new ValidateBusinessItemsBusinessRulesResponse(false, violations);
        }

        public static ValidateBusinessItemsBusinessRulesResponse Success()
        {
            return new ValidateBusinessItemsBusinessRulesResponse(true, null);
        }
    }
}