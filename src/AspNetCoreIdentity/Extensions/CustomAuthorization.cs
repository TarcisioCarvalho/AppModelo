using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;

namespace AspNetCoreIdentity.Extensions
{
    public class CustomAuthorization
    {
        public static bool ValidarClaimsUsuario(HttpContext httpContext,string claimName,string claimValue)
        {
            return httpContext.User.Identity.IsAuthenticated &&
                httpContext.User.Claims.Any(c => c.ValueType == claimName && c.Value.Contains(claimValue));
        }
       
    }

    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimName, string claimValue)
            : base(typeof(RequistoClaimFilter))
        {
            Arguments = new object[] { claimName, claimValue };
        }
    }
    public class RequistoClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public RequistoClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!CustomAuthorization.
                ValidarClaimsUsuario(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new ForbidResult();
            }
        }
    }

}
