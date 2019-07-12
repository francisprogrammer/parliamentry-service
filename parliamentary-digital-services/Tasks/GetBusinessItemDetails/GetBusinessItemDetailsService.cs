using System;
using System.Collections.Generic;
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
                return GetBusinessItemDetailsResponse.Failed(businessRuleResponse.ErrorMessages);

            var response =
                await _getParliamentEventDetails.GetParliamentEventDetails(
                new GetParliamentEventDetailsRequest(_getParliamentEventDetailsSettings.EndPoint, request.Id,
                    request.StartDate, request.EndDate));

            return GetBusinessItemDetailsResponse.Success(
                new BusinessItemDetailsModel(
                    response.BusinessItemDetails.Id,
                    response.BusinessItemDetails.StartDate.ToLongDateString(),
                    response.BusinessItemDetails.StartTime,
                    response.BusinessItemDetails.EndDate.ToLongDateString(),
                    response.BusinessItemDetails.EndTime,
                    response.BusinessItemDetails.Description,
                    response.BusinessItemDetails.Category,
                    response.BusinessItemDetails.Members.Any() 
                        ? response.BusinessItemDetails.Members.Select(memberItem => new MemberItemViewModel(memberItem.Id, memberItem.Name))
                        : new List<MemberItemViewModel>()));
        }
    } 
}