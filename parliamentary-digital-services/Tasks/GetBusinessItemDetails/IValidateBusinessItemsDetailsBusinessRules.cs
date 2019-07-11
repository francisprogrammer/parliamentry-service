using System.Text;
using System.Threading.Tasks;

namespace PD.Services.Tasks.GetBusinessItemDetails
{
    public interface IValidateBusinessItemsDetailsBusinessRules
    {
        ValidateBusinessItemsDetailsBusinessRulesResponse Validate(
            ValidateBusinessItemsDetailsBusinessRulesRequest request);
    }

}
