namespace PD.Services.Tasks.GetWeeks
{
    public class GetWeeksResponse
    {
        public GetWeeksViewModel GetWeeksViewModel { get; }

        public GetWeeksResponse(GetWeeksViewModel getWeeksViewModel)
        {
            GetWeeksViewModel = getWeeksViewModel;
        }
    }
}