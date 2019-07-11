using System.Collections.Generic;
using PD.Domain;
using PD.Services.Common;

namespace PD.Services.Tasks.GetBusinessItems
{
    public class GetParliamentEventResponse : Response
    {
        public Events Events { get; }

        public GetParliamentEventResponse(bool isSuccess, Events events) : base(isSuccess, null)
        {
            Events = events;
        }

        public static GetParliamentEventResponse Success(Events events)
        {
            return new GetParliamentEventResponse(true, events);
        }
    }
}