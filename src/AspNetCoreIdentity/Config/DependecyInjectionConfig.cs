using AspNetCoreIdentity.Extensions;
using Microsoft.AspNetCore.Authorization;
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
    }
}
