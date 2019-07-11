namespace PD.Services.Tasks.GetMemberDetails
{
    public class GetParliamentMemberDetailsRequest
    {
        public string Url { get; }
        public int Id { get; }

        public GetParliamentMemberDetailsRequest(string url, int id)
        {
            Url = url;
            Id = id;
        }
    }
}