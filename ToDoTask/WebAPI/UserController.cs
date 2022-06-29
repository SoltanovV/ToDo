using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoTask.Models;

namespace ToDoTask.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ApplicationContext db; 

        private readonly ILogger<UserController> _logger;

        [HttpPost]
        public async Task<IActionResult> Createuser([FromBody] User user)
        {
            var db1 = db.User.Where(u => u.Id == user.Id);
            return null;
        }
    }
}
