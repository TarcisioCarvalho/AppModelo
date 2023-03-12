using AspNetCoreIdentity.Areas.Identity.Data;
using AspNetCoreIdentity.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreIdentity.Config
{
    public static class DependecyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this  IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, PermissaoNecessariaHandler>();
            return services; 
        }

        public static IServiceCollection AddIdentityConfig(this IServiceCollection services,
            IConfiguration configuration
            )
        {
            services.AddDbContext<AspNetCoreIdentityContext>(options =>
                   options.UseSqlServer(
                       configuration.GetConnectionString("AspNetCoreIdentityContextConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.
            SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AspNetCoreIdentityContext>();
            return services;
        }
    }
}
