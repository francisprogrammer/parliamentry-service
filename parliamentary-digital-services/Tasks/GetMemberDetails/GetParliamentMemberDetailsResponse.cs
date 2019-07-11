using System.Collections.Generic;
using System.Threading.Tasks;
using PD.Domain;
using PD.Services.Common;

namespace PD.Services.Tasks.GetMemberDetails
{
    public class GetParliamentMemberDetailsResponse : Response
    {
        public MemberDetails MemberDetails { get; }

        public GetParliamentMemberDetailsResponse(bool isSuccess, MemberDetails memberDetails, IEnumerable<string> errorMessageses) : base(isSuccess, errorMessageses)
        {
            MemberDetails = memberDetails;
        }

        public static GetParliamentMemberDetailsResponse Success(MemberDetails memberDetails)
        {
            return new GetParliamentMemberDetailsResponse(true, memberDetails, null);
        }
    }
}