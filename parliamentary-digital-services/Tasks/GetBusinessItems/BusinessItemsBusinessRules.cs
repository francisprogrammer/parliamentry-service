using System.Collections.Generic;
using System.Linq;

namespace PD.Services.Tasks.GetBusinessItems
{
    public class BusinessItemsBusinessRules : IValidateBusinessItemsBusinessRules
    {
        public ValidateBusinessItemsBusinessRulesResponse Validate(ValidateBusinessItemsBusinessRulesRequest request)
        {
            var violations = new List<string>();

            if (request.StartDate.Date > request.EndDate.Date)
                violations.Add("End date must come before start date");

            return violations.Any()
                ? ValidateBusinessItemsBusinessRulesResponse.Failed(violations)
                : ValidateBusinessItemsBusinessRulesResponse.Success();
        }
    }
}