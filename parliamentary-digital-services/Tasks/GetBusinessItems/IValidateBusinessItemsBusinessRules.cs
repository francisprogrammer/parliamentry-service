namespace PD.Services.Tasks.GetBusinessItems
{
    public interface IValidateBusinessItemsBusinessRules
    {
        ValidateBusinessItemsBusinessRulesResponse ValidateBusinessItemsBusinessRules(
            ValidateBusinessItemsBusinessRulesRequest request);
    }
}