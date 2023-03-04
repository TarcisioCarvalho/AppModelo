using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreIdentity.Extensions
{
    public class PermissaoNecesssaria : IAuthorizationRequirement
    {
        public string Permissao { get; }
    }


}
