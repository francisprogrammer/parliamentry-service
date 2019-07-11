namespace PD.Services.Tasks.GetMemberDetails
{
    public class GetMemberDetailsModel
    {
        public string Party { get; }
        public string MemberFrom { get; }
        public string FullTitle { get; }

        public GetMemberDetailsModel(string party, string memberFrom, string fullTitle)
        {
            Party = party;
            MemberFrom = memberFrom;
            FullTitle = fullTitle;
        }
    }
}