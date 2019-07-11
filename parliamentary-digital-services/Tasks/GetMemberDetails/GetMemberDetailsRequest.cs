namespace PD.Services.Tasks.GetMemberDetails
{
    public class GetMemberDetailsRequest
    {
        public int Id { get; }

        public GetMemberDetailsRequest(int id)
        {
            Id = id;
        }
    }
}