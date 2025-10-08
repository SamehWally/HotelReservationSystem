using System.Security.Claims;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.Filters
{
    public class CustomAuthorizeFilter : ActionFilterAttribute
    {
        private readonly string _featureName;
        private readonly RoleFeatureService _roleFeatureService;

        public CustomAuthorizeFilter(string featureName, RoleFeatureService roleFeatureService)
        {
            _featureName = featureName;
            _roleFeatureService = roleFeatureService;
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var user = context.HttpContext.User;

            if (user == null || !user.Identity!.IsAuthenticated)
            {
                context.Result = new JsonResult(new
                {
                    Message = "Unauthorized: Missing or invalid token."
                })
                { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }
            
            
            var roleClaims = user.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();

            if (!roleClaims.Any())
            {
                context.Result = new JsonResult(new
                {
                    Message = "Forbidden: No roles found in token."
                })
                { StatusCode = StatusCodes.Status403Forbidden };
                return;
            }

            bool hasAccess = false;

            
            foreach (var roleClaim in roleClaims)
            {
                if (int.TryParse(roleClaim, out int roleId))
                {
                    if (await _roleFeatureService.CheckFeatureAccess(roleId, _featureName))
                    {
                        hasAccess = true;
                        break;
                    }
                }
            }

            if (!hasAccess)
            {
                context.Result = new JsonResult(new
                {
                    Message = $"Forbidden: None of your roles have access to '{_featureName}'."
                })
                { StatusCode = StatusCodes.Status403Forbidden };
                return;
            }

            await next();
        }
    }
}
