using System.Threading.Tasks;

namespace PD.Services.Tasks.GetBusinessItems
{
    public interface IGetBusinessItemBetweenDates
    {
        Task<GetBusinessItemBetweenDatesResponse> GetBusinessItemBetweenDates(GetBusinessItemBetweenDatesRequest request);
    }
}