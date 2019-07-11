using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace PD.Services.Tasks.GetBusinessItemDetails
{
    public class GetBusinessItemDetailsService : IGetBusinessItemDetails
    {
        private readonly IGetParliamentEventDetails _getParliamentEventDetails;
        private readonly IValidateBusinessItemsDetailsBusinessRules _validateBusinessItemsDetailsBusinessRules;
        private readonly GetParliamentEventDetailsSettings _getParliamentEventDetailsSettings;

        public GetBusinessItemDetailsService(
            IOptions<GetParliamentEventDetailsSettings> getParliamentEventDetailsSettings,
            IGetParliamentEventDetails getParliamentEventDetails,
            IValidateBusinessItemsDetailsBusinessRules validateBusinessItemsDetailsBusinessRules)
        {
            _getParliamentEventDetails = getParliamentEventDetails;
            _validateBusinessItemsDetailsBusinessRules = validateBusinessItemsDetailsBusinessRules;
            _getParliamentEventDetailsSettings = getParliamentEventDetailsSettings.Value;
        }

        public async Task<GetBusinessItemDetailsResponse> GetBusinessItemDetails(GetBusinessItemDetailsRequest request)
        {
            var businessRuleResponse =
                _validateBusinessItemsDetailsBusinessRules
                    .Validate(new ValidateBusinessItemsDetailsBusinessRulesRequest(request.Id, request.StartDate, request.EndDate));

            if (!businessRuleResponse.IsSuccess)
                return GetBusinessItemDetailsResponse.Failed(businessRuleResponse.ErrorMessageses);

            var response =
                await _getParliamentEventDetails.GetParliamentEventDetails(
                new GetParliamentEventDetailsRequest(_getParliamentEventDetailsSettings.EndPoint, request.Id,
                    request.StartDate, request.EndDate));

            return GetBusinessItemDetailsResponse.Success(
                new BusinessItemDetailsModel(
                    response.BusinessItemDetails.StartDateAndTime,
                    response.BusinessItemDetails.EndDateAndTime,
                    response.BusinessItemDetails.Description,
                    response.BusinessItemDetails.Category,
                    response.BusinessItemDetails.Members.Select(memberItem => new MemberItemViewModel(memberItem.Id, memberItem.Name))));
        }
    }
}