using System.Threading.Tasks;

namespace PD.Services.Tasks.GetMemberDetails
{
    public interface IGetParliamentMemberDetails
    {
        Task<GetParliamentMemberDetailsResponse> GetGetParliamentMemberDetails(GetParliamentMemberDetailsRequest request);
    }
}