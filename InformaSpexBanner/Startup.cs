﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InformaSpexBanner.Data;
using InformaSpexBanner.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace InformaSpexBanner
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add framework services.
			services.AddMvc();
            services.Configure<IpSecuritySettings>(Configuration.GetSection("AdminHash"));

			services.AddScoped<ISpexBannerRepository, SpexBannerRepository>();

			var dbConnectionString = Configuration["InfSS1ConnectionString"];
			//Console.WriteLine(dbConnectionString);
			services.AddDbContext<InformaSS1DbContext>(options => options.UseSqlServer(dbConnectionString));
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }



			app.UseMiddleware<IpRestrictionMiddleware>();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
				routes.MapRoute(
					name: "areaRoute",
					template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
