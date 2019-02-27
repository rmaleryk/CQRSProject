using System.Collections.Generic;
using CQRSProject.Commands.CommandDispatchers;
using CQRSProject.Commands.CommandHandlers;
using CQRSProject.Commands.Commands;
using CQRSProject.Commands.Extensibility;
using CQRSProject.Core.Entities;
using CQRSProject.Core.Extensibility.Repositories;
using CQRSProject.DataAccess.Read.Extensions;
using CQRSProject.DataAccess.Read.Repositories;
using CQRSProject.DataAccess.Write.Repositories;
using CQRSProject.DataAccess.Write.Extensions;
using CQRSProject.Infrastructure.EventStore;
using CQRSProject.Infrastructure.EventStore.EventHandlers;
using CQRSProject.Infrastructure.EventStore.Extensibility.EventHandlers;
using CQRSProject.Queries.Extensibility;
using CQRSProject.Queries.Queries;
using CQRSProject.Queries.QueryDispatchers;
using CQRSProject.Queries.QueryHandlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSProject.WebApi
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
            services.AddDbContext(Configuration.GetConnectionString("WriteDatabase"));
            services.AddReadMongoDb(Configuration.GetConnectionString("ReadDatabase"), "userActivities");

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IUserActivityReadRepository, UserActivityReadRepository>();
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.AddScoped<IQueryHandler<GetUserActivityByIdQuery, IEnumerable<UserActivity>>, UserActivityQueryHandler>();

            services.AddScoped<IWriteRepository<UserLocation>, UserLocationWriteRepository>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<ICommandHandler<AddUserLocation>, UserLocationCommandHandler>();

            services.AddScoped<IEventStore, EventStore>();
            services.AddScoped<IEventHandler<AddUserLocation>, AddUserLocationEventHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc();
        }
    }
}
