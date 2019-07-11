using System.Threading.Tasks;

namespace PD.Services.Tasks.GetMemberDetails
{
    public interface IGetMemberDetails
    {
        Task<GetMemberDetailsResponse> GetMemberDetails(GetMemberDetailsRequest request);
    }
}