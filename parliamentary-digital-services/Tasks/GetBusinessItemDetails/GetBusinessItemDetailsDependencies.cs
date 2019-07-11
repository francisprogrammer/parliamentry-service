using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PD.Services.Common;

namespace PD.Services.Tasks.GetBusinessItemDetails
{
    public static class GetBusinessItemDetailsDependencies
    {
        public static void AddGetBusinessItemDetailsDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IGetBusinessItemDetails, GetBusinessItemDetailsService>();
            serviceCollection.AddTransient<IValidateBusinessItemsDetailsBusinessRules, BusinessItemsDetailsBusinessRules>();

            serviceCollection.Configure<GetParliamentEventDetailsSettings>(AppSettings.CreateConfigurationRoot().GetSection("GetParliamentEventDetailsSettings"));
        }
    }
}
