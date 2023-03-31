using Microsoft.AspNetCore.Mvc;

using TestAPISql.Modules.Users.Services;

namespace TestAPISql.Modules.Users
{
    [ApiController]
    [Route("users")]
    public class UserControler : ControllerBase
    {
        private readonly IUserService _userService;
        public UserControler(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var users = await _userService.GetUsersAsync();

            if (users == null)
                return NotFound();

            return new JsonResult(new { users = users });
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if(user == null)
                return NotFound();

            return new JsonResult(new { user = user });
        }

        [HttpPut("user/{id}/asnotracking")]
        public async Task<IActionResult> UpdateUserAsNoTracking([FromRoute] int id)
        {
            var user = await _userService.UpdateUserAsNoTracking(id);

            if(user == null)
                return NotFound();

            return new JsonResult(new { user = user });
        }

        [HttpPut("user/{id}/ForUpdate")]
        public async Task<IActionResult> UpdateUserForUpdate([FromRoute] int id)
        {
            var user = await _userService.UpdateUserForUpdate(id);

            if(user == null)
                return NotFound();

            return new JsonResult(new { user = user });
        }

        [HttpPut("user/{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id)
        {
            var user = await _userService.UpdateUser(id);

            if(user == null)
                return NotFound();

            return new JsonResult(new { user = user });
        }

        [HttpDelete("user/{id}")]
        public async Task<IActionResult> DeleteUserById([FromRoute] int id)
        {
            var status = await _userService.DeleteUserByIdAsync(id);
            
            if(status == 0)
                return NotFound();
            if(status == -1)
                return StatusCode(500);

            return Ok(status);
        }
    }
}
