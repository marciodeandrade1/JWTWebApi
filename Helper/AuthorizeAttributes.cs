using JWTWebApi.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace JWTWebApi.Helper
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttributes : Attribute, IAuthorizationFilter
    {
        private readonly IList<Role> _roles;

        public AuthorizeAttributes(params Role[] _roles)
        {
            this._roles = _roles ?? new Role[] { };
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isRolePermission = false;
            User user = (User)context.HttpContext.Items["User"];
            if (user == null)
            {
                context.Result = new JsonResult(new { Message = "Unauthorization" })
                { StatusCode = StatusCodes.Status401Unauthorized };
            }
            if (user != null && this._roles.Any())
                foreach (var userRole in user.Role)
                {
                    foreach (var AuthRole in this._roles)
                    {
                        if (userRole == AuthRole)
                        {
                            isRolePermission = true;
                        }
                    }
                }
            if (!isRolePermission)
                context.Result = new JsonResult(new { Message = "Unauthorization" })
                { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}
