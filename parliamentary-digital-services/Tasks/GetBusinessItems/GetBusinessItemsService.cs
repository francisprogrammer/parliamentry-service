using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace PD.Services.Tasks.GetBusinessItems
{
    public class GetBusinessItemsService : IGetBusinessItemBetweenDates
    {
        private readonly IGetParliamentEvents _getParliamentEvents;
        private readonly IValidateBusinessItemsBusinessRules _validateBusinessItemsBusinessRules;
        private readonly ParliamentEventsEndPointSettings _parliamentEventsEndPointSettings;

        public GetBusinessItemsService(
            IOptions<ParliamentEventsEndPointSettings> parliamentEventsEndPointSettings,
            IGetParliamentEvents getParliamentEvents,
            IValidateBusinessItemsBusinessRules validateBusinessItemsBusinessRules)
        {
            _getParliamentEvents = getParliamentEvents;
            _validateBusinessItemsBusinessRules = validateBusinessItemsBusinessRules;
            _parliamentEventsEndPointSettings = parliamentEventsEndPointSettings.Value;
        }
        
        public async Task<GetBusinessItemBetweenDatesResponse> GetBusinessItemBetweenDates(GetBusinessItemBetweenDatesRequest request)
        {
            var businessRuleResponse =
                _validateBusinessItemsBusinessRules
                    .ValidateBusinessItemsBusinessRules(
                        new ValidateBusinessItemsBusinessRulesRequest(request.StartDate, request.EndDate));

            if (!businessRuleResponse.IsSuccess)
            {
                return GetBusinessItemBetweenDatesResponse.Failed(businessRuleResponse.ErrorMessage);
            }
            
            var response =
                await _getParliamentEvents
                    .GetEvents(new GetParliamentEventsRequest(_parliamentEventsEndPointSettings.EndPoint, request.StartDate,
                        request.EndDate));
            
            return GetBusinessItemBetweenDatesResponse.Success(response.Events.Select(@event => new BusinessItemModel(@event.StartDateAndTime, @event.EndDateAndTime, @event.Description)));
        }
    }
}