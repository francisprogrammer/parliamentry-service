using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace PD.Services.Tasks.GetMemberDetails
{
    public class GetMemberDetailsService : IGetMemberDetails
    {
        private readonly ParliamentMemberDetailsEndPointSettings _parliamentMemberDetailsEndPointSettings;
        private readonly IGetParliamentMemberDetails _getParliamentMemberDetails;

        public GetMemberDetailsService(IOptions<ParliamentMemberDetailsEndPointSettings> parliamentMemberDetailsEndPointSettings, IGetParliamentMemberDetails getParliamentMemberDetails)
        {
            _parliamentMemberDetailsEndPointSettings = parliamentMemberDetailsEndPointSettings.Value;
            _getParliamentMemberDetails = getParliamentMemberDetails;
        }

        public async Task<GetMemberDetailsResponse> GetMemberDetails(GetMemberDetailsRequest request)
        {
            var response = await _getParliamentMemberDetails.GetGetParliamentMemberDetails(
                new GetParliamentMemberDetailsRequest(_parliamentMemberDetailsEndPointSettings.EndPoint, request.Id));
            return GetMemberDetailsResponse.Success(response.MemberDetails);
        }
    }
}