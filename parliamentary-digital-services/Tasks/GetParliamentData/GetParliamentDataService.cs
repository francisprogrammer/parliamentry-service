using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PD.Domain;
using PD.Services.Tasks.GetBusinessItemDetails;
using PD.Services.Tasks.GetBusinessItems;
using PD.Services.Tasks.GetMemberDetails;

namespace PD.Services.Tasks.GetParliamentData
{
    class GetParliamentDataService : IGetParliamentEvents, IGetParliamentEventDetails, IGetParliamentMemberDetails
    {
        public async Task<GetParliamentEventResponse> GetEvents(GetParliamentEventsRequest request)
        {
            return null;
        }

        public async Task<GetParliamentEventDetailsResponse> GetParliamentEventDetails(GetParliamentEventDetailsRequest request)
        {
            return null;
        }

        public async Task<GetParliamentMemberDetailsResponse> GetGetParliamentMemberDetails(GetParliamentMemberDetailsRequest request)
        {
            return null;
        }
    }
}