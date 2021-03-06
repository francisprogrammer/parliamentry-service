﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PD.Services.Common;
using PD.Services.Tasks.GetBusinessItemDetails;
using PD.Services.Tasks.GetBusinessItems;
using PD.Services.Tasks.GetDateAndTime;
using PD.Services.Tasks.GetMemberDetails;
using PD.Services.Tasks.GetParliamentData;
using PD.Services.Tasks.GetWeeks;

namespace PD.WebApi
{
    public class Startup
    {
        public Startup()
        {
            Configuration = AppSettings.CreateConfigurationRoot();
        }
        
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:8000").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                    });
            });
            services.AddGetWeeksDependencies();
            services.AddGetParliamentDataDependencies();
            services.AddGetMemberDetailsDependencies();
            services.AddGetDateAndTimeDependencies();
            services.AddGetBusinessItemsDependencies();
            services.AddGetBusinessItemDetailsDependencies();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(MyAllowSpecificOrigins);
            app.UseMvc();
        }
    }
}
