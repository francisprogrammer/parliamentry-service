using System.Collections.Generic;
using PD.Domain;
using PD.Services.Common;

namespace PD.Services.Tasks.GetBusinessItems
{
    public class GetParliamentEventResponse : Response
    {
        public IEnumerable<Event> Events { get; }
        
        public GetParliamentEventResponse(bool isSuccess, IEnumerable<Event> events) : base(isSuccess, null)
        {
            Events = events;
        }
    }
}