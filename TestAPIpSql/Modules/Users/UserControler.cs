using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TestAPISql.Modules.Users
{
    [ApiController]
    [Route("users")]
    public class UserControler : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserControler(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var user = await _context.User.FindAsync(u => u.id == 2);

            if (user == null) return NotFound();

            return new JsonResult(new { user = user });
        }
    }
}
