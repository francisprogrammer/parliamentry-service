using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PD.Services.Tasks.GetBusinessItemDetails;
using PD.Services.Tasks.GetBusinessItems;
using PD.Services.Tasks.GetMemberDetails;

namespace PD.Services.Tasks.GetParliamentData
{
    public static class GetParliamentDataDependencies
    {
        public static void AddGetParliamentDataDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IGetParliamentEventDetails, GetParliamentDataService>();
            serviceCollection.AddTransient<IGetParliamentEvents, GetParliamentDataService>();
            serviceCollection.AddTransient<IGetParliamentMemberDetails, GetParliamentDataService>();
        }
    }
}
