using PD.Services.Common;

namespace PD.Services.Tasks.GetBusinessItems
{
    public class ValidateBusinessItemsBusinessRulesResponse : Response
    {
        public ValidateBusinessItemsBusinessRulesResponse(bool isSuccess) : base(isSuccess, null)
        {
        }
    }
}