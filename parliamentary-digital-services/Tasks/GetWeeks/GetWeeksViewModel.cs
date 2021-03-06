using System.Collections.Generic;

namespace PD.Services.Tasks.GetWeeks
{
    public class GetWeeksViewModel
    {
        public IEnumerable<WeekViewModel> Weeks { get; }

        public GetWeeksViewModel(IEnumerable<WeekViewModel> weeks)
        {
            Weeks = weeks;
        }
    }
}