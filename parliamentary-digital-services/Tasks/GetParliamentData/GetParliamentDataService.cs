using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PD.Domain;
using PD.Services.Tasks.GetBusinessItems;

namespace PD.Services.Tasks.GetParliamentData
{
    class GetParliamentDataService : IGetParliamentEvents
    {
        public async Task<GetParliamentEventResponse> Get(GetParliamentEventsRequest request)
        {
            return null;
        }
    }
}