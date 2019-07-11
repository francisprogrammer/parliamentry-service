using System.Threading.Tasks;

namespace PD.Services.Tasks.GetBusinessItems
{
    public interface IGetParliamentEvents
    {
        Task<GetParliamentEventResponse> Get(GetParliamentEventsRequest request);
    }
}