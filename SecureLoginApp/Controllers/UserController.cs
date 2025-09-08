using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

[Authorize(Roles = "User")]
public class UserController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> UserProfile()
    {
        var user = await _userManager.GetUserAsync(User);
        return View(user);
    }
}
