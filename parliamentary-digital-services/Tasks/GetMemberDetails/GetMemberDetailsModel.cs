namespace PD.Services.Tasks.GetMemberDetails
{
    public class GetMemberDetailsModel
    {
        public int Id { get; }
        public string Party { get; }
        public string MemberFrom { get; }
        public string FullTitle { get; }

        public GetMemberDetailsModel(int id, string party, string memberFrom, string fullTitle)
        {
            Party = party;
            MemberFrom = memberFrom;
            FullTitle = fullTitle;
            Id = id;
        }
    }
}