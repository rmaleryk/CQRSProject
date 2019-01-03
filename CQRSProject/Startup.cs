using System.Collections.Generic;
using CQRSProject.Commands.CommandDispatchers;
using CQRSProject.Commands.CommandHandlers;
using CQRSProject.Commands.Commands;
using CQRSProject.Commands.Extensibility;
using CQRSProject.DataAccess.Read.Repositories;
using CQRSProject.DataAccess.Write.Repositories;
using CQRSProject.Domain.Entities;
using CQRSProject.Domain.Extensibility.Repositories;
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IReadRepository<ShopItem>, ShopItemReadRepository>();
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.AddScoped<IQueryHandler<FindShopItemsByName, IEnumerable<ShopItem>>, ShopItemQueryHandler>();

            services.AddScoped<IWriteRepository<ShopItem>, ShopItemWriteRepository>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<ICommandHandler<CreateShopItem>, ShopCommandHandler>();

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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
