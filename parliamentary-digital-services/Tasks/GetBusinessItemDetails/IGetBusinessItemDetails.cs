using System.Threading.Tasks;

namespace PD.Services.Tasks.GetBusinessItemDetails
{
    public interface IGetBusinessItemDetails
    {
        Task<GetBusinessItemDetailsResponse> GetBusinessItemDetails(GetBusinessItemDetailsRequest request);
    }
}