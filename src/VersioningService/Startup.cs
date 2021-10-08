using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VersioningService.Core.Interfaces.Repositories;
using VersioningService.Core.Interfaces.Services;
using VersioningService.Core.Services;
using VersioningService.Infrastructure.Context;
using VersioningService.Infrastructure.Repositories;

namespace VersioningService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            //var options = new DbContextOptionsBuilder<VersioningDbContext>()
            //.UseInMemoryDatabase(databaseName: "DiagAc2Tests")
            //.Options;
            services.AddDbContext<VersioningDbContext>(opts => opts.UseInMemoryDatabase("MemInDB")); // This is just a workaround for using in-memory storage temporaly

            services.AddScoped<IMicrofrontEndService, MicrofrontEndService>();
            services.AddScoped<IMicrofrontEndRepository, MicrofronEndRepository>();

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
