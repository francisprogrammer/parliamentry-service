using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace PD.Services.Tasks.GetDateAndTime
{
    public static class GetDateAndTimeDependencies
    {
        public static void AddGetDateAndTimeDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDateTimeService, GetDateAndTimeService>();
        }
    }
}
