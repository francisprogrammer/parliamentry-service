using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace PD.Services.Tasks.GetBusinessItemDetails
{
    public class GetBusinessItemDetailsService : IGetBusinessItemDetails
    {
        private readonly IGetParliamentEventDetails _getParliamentEventDetails;
        private readonly GetParliamentEventDetailsSettings _getParliamentEventDetailsSettings;

        public GetBusinessItemDetailsService(
            IOptions<GetParliamentEventDetailsSettings> getParliamentEventDetailsSettings,
            IGetParliamentEventDetails getParliamentEventDetails)
        {
            _getParliamentEventDetails = getParliamentEventDetails;
            _getParliamentEventDetailsSettings = getParliamentEventDetailsSettings.Value;
        }
        
        public async Task<GetBusinessItemDetailsResponse> GetBusinessItemDetails(GetBusinessItemDetailsRequest request)
        {
            var response = 
                await _getParliamentEventDetails.GetParliamentEventDetails(
                new GetParliamentEventDetailsRequest(_getParliamentEventDetailsSettings.EndPoint, request.Id,
                    request.StartDate, request.EndDate));
            
            return new GetBusinessItemDetailsResponse(
                new BusinessItemDetailsModel(
                    response.BusinessItemDetails.StartDateAndTime,
                    response.BusinessItemDetails.EndDateAndTime,
                    response.BusinessItemDetails.Description,
                    response.BusinessItemDetails.Category,
                    response.BusinessItemDetails.Members.Select(memberItem => new MemberItemViewModel(memberItem.Id, memberItem.Name))));
        }
    }
}