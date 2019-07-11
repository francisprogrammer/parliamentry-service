using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace PD.Services.Tasks.GetBusinessItems
{
    public class GetBusinessItemsService : IGetBusinessItemBetweenDates
    {
        private readonly IGetParliamentEvents _getParliamentEvents;
        private readonly ParliamentEventsEndPointSettings _parliamentEventsEndPointSettings;

        public GetBusinessItemsService(
            IOptions<ParliamentEventsEndPointSettings> parliamentEventsEndPointSettings,
            IGetParliamentEvents getParliamentEvents)
        {
            _getParliamentEvents = getParliamentEvents;
            _parliamentEventsEndPointSettings = parliamentEventsEndPointSettings.Value;
        }
        
        public async Task<GetBusinessItemBetweenDatesResponse> GetBusinessItemBetweenDates(GetBusinessItemBetweenDatesRequest request)
        {
            var response =
                await _getParliamentEvents
                    .GetEvents(new GetParliamentEventsRequest(_parliamentEventsEndPointSettings.EndPoint, request.StartDate,
                        request.EndDate));
            
            return new GetBusinessItemBetweenDatesResponse(true, response.Events.Select(@event => new BusinessItemModel(@event.StartDateAndTime, @event.EndDateAndTime, @event.Description)));
        }
    }
}