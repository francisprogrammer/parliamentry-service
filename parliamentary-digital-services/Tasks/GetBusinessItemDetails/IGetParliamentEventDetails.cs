using System.Threading.Tasks;

namespace PD.Services.Tasks.GetBusinessItemDetails
{
    public interface IGetParliamentEventDetails
    {
        Task<GetParliamentEventDetailsResponse> GetParliamentEventDetails(GetParliamentEventDetailsRequest request);
    }
}