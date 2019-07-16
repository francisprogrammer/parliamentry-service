using Microsoft.Extensions.DependencyInjection;
using PD.Services.Common;
using PD.Services.Tasks.GetParliamentData;

namespace PD.Services.Tasks.GetBusinessItems
{
    public static class GetBusinessItemsDependencies
    {
        public static void AddGetBusinessItemsDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IGetParliamentEvents, GetParliamentDataService>();
            serviceCollection.AddTransient<IGetBusinessItemBetweenDates, GetBusinessItemsService>();
            serviceCollection.AddTransient<IValidateBusinessItemsBusinessRules, BusinessItemsBusinessRules>();

            serviceCollection.Configure<ParliamentEventsEndPointSettings>(AppSettings.CreateConfigurationRoot().GetSection("ParliamentEventsEndPointSettings"));
        }
    }
}