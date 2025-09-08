using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class AuthFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var isAuthenticated = context.HttpContext.User.Identity?.IsAuthenticated ?? false;
        if (!isAuthenticated)
        {
            context.Result = new RedirectToActionResult("Login", "Account", null);
        }
    }
}
