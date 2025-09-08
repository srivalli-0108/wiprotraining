using Microsoft.AspNetCore.Mvc;
using DoConnectBackend.Models;
using DoConnectBackend.Services;
using Microsoft.AspNetCore.Authorization;

namespace DoConnectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
