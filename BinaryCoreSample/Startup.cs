using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BinaryCoreSample.Services;
using BinaryCoreSample.Models;
using Microsoft.EntityFrameworkCore;

namespace BinaryCoreSample
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
            services.AddTransient<IHouseService, HouseService>();
            services.AddTransient<CustomService>();

            string con = "Server=(localdb)\\mssqllocaldb;Database=Houses;Trusted_Connection=True;MultipleActiveResultSets=true";
            services.AddDbContext<HouseContext>(options => options.UseSqlServer(con));
 
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, HouseContext context, ILoggerFactory loggerFactory)
        {
            
            HouseService service = new HouseService(context);
            DbInitializer dbinitializer = new DbInitializer(service);
            dbinitializer.Initialize();
            app.UseMvc();
        }
    }
}
