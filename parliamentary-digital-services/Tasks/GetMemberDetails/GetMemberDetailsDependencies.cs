using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PD.Services.Common;

namespace PD.Services.Tasks.GetMemberDetails
{
    public static class GetMemberDetailsDependencies
    {
        public static void AddGetMemberDetailsDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IGetMemberDetails, GetMemberDetailsService>();
            serviceCollection.Configure<ParliamentMemberDetailsEndPointSettings>(AppSettings.CreateConfigurationRoot().GetSection("ParliamentMemberDetailsEndPointSettings"));
        }
    }
}
