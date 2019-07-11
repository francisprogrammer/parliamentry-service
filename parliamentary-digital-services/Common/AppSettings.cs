using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace PD.Services.Common
{
    public class AppSettings
    {
        private static IConfigurationRoot _configurationRoot;
        
        public static IConfigurationRoot CreateConfigurationRoot()
        {
            if (_configurationRoot != null) return _configurationRoot;
            
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configBuilder =
                new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false);
            
            _configurationRoot = configBuilder.Build();
            
            return _configurationRoot;
        }
    }
}