namespace PD.Domain
{
    public class MemberDetails
    {
        public string Party { get; }
        public string MemberFrom { get; }
        public string FullTitle { get; }

        public MemberDetails(string party, string memberFrom, string fullTitle)
        {
            Party = party;
            MemberFrom = memberFrom;
            FullTitle = fullTitle;
        }
    }
}