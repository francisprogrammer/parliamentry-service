using System.Collections.Generic;
using System.Linq;

namespace PD.Services.Tasks.GetBusinessItemDetails
{
    public class BusinessItemsDetailsBusinessRules : IValidateBusinessItemsDetailsBusinessRules
    {
        public ValidateBusinessItemsDetailsBusinessRulesResponse Validate(ValidateBusinessItemsDetailsBusinessRulesRequest request)
        {
            var violations = new List<string>();

            if (request.StartDate.Date > request.EndDate.Date)
                violations.Add("End date must come before start date");

            return violations.Any()
                ? ValidateBusinessItemsDetailsBusinessRulesResponse.Failed(violations)
                : ValidateBusinessItemsDetailsBusinessRulesResponse.Success();
        }
    }
}