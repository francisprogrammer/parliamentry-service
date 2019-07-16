namespace PD.Services.Tasks.GetBusinessItems
{
    public interface IValidateBusinessItemsBusinessRules
    {
        ValidateBusinessItemsBusinessRulesResponse Validate(ValidateBusinessItemsBusinessRulesRequest request);
    }
}