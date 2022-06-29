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
         //TODO: Доделать Api для создания пользователя 
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
           db.User.Where(u => u.Id == user.Id);
            return null;
        }
    }
}
