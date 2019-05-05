using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Routes.API.Middlewares;
using Routes.API.Profiles;
using Routes.Application.Interfaces;
using Routes.Application.Populator;
using Routes.Application.Routes;
using Routes.Core.Interfaces;
using Routes.Infrastructure.Data;
using Routes.Infrastructure.FileHandler;
using Routes.Infrastructure.Interfaces;


namespace Routes.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("RoutesDb"));

            services.AddAutoMapper();

            services.AddScoped<IAppPopulator, AppPopulator>();
            services.AddScoped<IAppRoutes, AppRoutes>();
            services.AddScoped<IFileReader, FileReader>();
            services.AddScoped<IRepository, Repository>();

            var mappingConfig = new MapperConfiguration(c =>
            {
                c.AddProfile(new AirlineViewModelProfile());
                c.AddProfile(new AirportViewModelProfile());
                c.AddProfile(new ConnectionViewModelProfile());
                c.AddProfile(new RouteViewModelProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMvc();
        }
    }
}