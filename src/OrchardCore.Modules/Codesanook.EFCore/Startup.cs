using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.Data.Migration;
using OrchardCore.Environment.Shell;
using OrchardCore.Environment.Shell.Configuration;
using OrchardCore.Modules;

namespace Codesanook.EFCore
{
    public class Startup : StartupBase
    {
        private readonly IShellConfiguration _configuration;
        private readonly ShellSettings _shellSettings;
        private readonly IOptions<ShellOptions> _shellOptions;

        public Startup(
            IShellConfiguration configuration,
            ShellSettings shellSettings,
            IOptions<ShellOptions> shellOptions)
            
        {
            _configuration = configuration;
            _shellSettings = shellSettings;
            _shellOptions = shellOptions;
        }

        // https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-3.1
        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            var provider = _configuration.GetValue<string>("DatabaseProvider");
            //EF context object has a default life time scoped which is per a per-request lifetime.
            // https://github.com/dotnet/efcore/issues/4988
            services.AddDbContext<OrchardDbContext>(options => {
                options.UseSqlServer(_configuration.GetValue<string>("ConnectionString"));
            });

            // Migration, can be removed in a future release.
            services.AddSingleton<IDataMigration, Migrations>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "Codesanook.EFCore",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
