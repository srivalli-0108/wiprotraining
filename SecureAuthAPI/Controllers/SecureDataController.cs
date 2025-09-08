using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class SecureDataController : ControllerBase
{
    [HttpGet]
    public IActionResult GetSecureData()
    {
        var userId = User.Claims.First(c => c.Type == "UserId").Value;

        return Ok(new
        {
            message = "Secure data accessed successfully.",
            data = new { user_id = userId, secure_info = "This is some sensitive user data." }
        });
    }
}
