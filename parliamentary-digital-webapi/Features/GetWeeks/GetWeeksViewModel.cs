using System.Collections.Generic;

namespace PD.WebApi.Features.GetWeeks
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