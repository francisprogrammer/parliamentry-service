using Microsoft.Extensions.DependencyInjection;
using PD.Services.Common;

namespace PD.Services.Tasks.GetWeeks
{
    public static class GetWeeksDependencies
    {
        public static void AddGetWeeksDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IGetWeeks, GetWeeksService>();
            serviceCollection.Configure<GetWeekSettings>(AppSettings.CreateConfigurationRoot().GetSection("PostalCodeGeolocationSettings"));
        }
    }
}