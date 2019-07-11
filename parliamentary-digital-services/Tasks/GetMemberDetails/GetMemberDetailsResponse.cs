using System.Collections.Generic;
using PD.Domain;
using PD.Services.Common;

namespace PD.Services.Tasks.GetMemberDetails
{
    public class GetMemberDetailsResponse : Response
    {
        public GetMemberDetailsModel GetMemberDetailsModel { get; }

        private GetMemberDetailsResponse(bool isSuccess, GetMemberDetailsModel getMemberDetailsModel, IEnumerable<string> errorMessages) : base(isSuccess, errorMessages)
        {
            GetMemberDetailsModel = getMemberDetailsModel;
        }

        public static GetMemberDetailsResponse Success(MemberDetails memberDetails)
        {
            return new GetMemberDetailsResponse(true, new GetMemberDetailsModel(memberDetails.Id, memberDetails.Party, memberDetails.MemberFrom, memberDetails.FullTitle), null);
        }
    }
}