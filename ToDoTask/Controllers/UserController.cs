using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoTask.Models;
using AspBackend.Models.Entity;
using AspBackend.Models.ViewModel;
using AspBackend.Services.Interface;

namespace ASPBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private IUserServices _userService;
        private ApplicationContext _db;

        public UserController(ApplicationContext db, ILogger<UserController> logger, IUserServices userService)
        {
            _db = db;
            _logger = logger;
            _userService = userService;
        }

        [Route("view")]
        [HttpGet]
        public async Task<IActionResult> ViewAllUser()
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                var result = _db.User
                    .Include(u => u.Account)
                    .Include(u => u.UserTodo)
                        .ThenInclude(ut => ut.Todo)
                    
                    .ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(_logger);
            }
        }

        [Route("view/Account")]
        [HttpGet]
        public async Task<IActionResult> ViewAccount()
        {
            try
            {
                _logger.LogInformation("Запрос получен ViewAccount получен");
                var result = _db.Account.Include(a => a.User).ThenInclude(u => u.UserProject);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(_logger);
            }
        }

        [Route("view/{id}")]
        [HttpGet]
        public async Task<IActionResult> ViewUser(int id)
        {
            try
            {
                _logger.LogInformation("Запрос ViewUser получен");

                var result = _db.User
                    .Where(u => u.Id == id)
                    .Include(u => u.UserTodo)
                    .ThenInclude(ut => ut.Todo)
                    .FirstOrDefault();
                   
                if (result != null)
                {
                    _logger.LogInformation("Запрос ViewUser выполнен");
                    return Ok(result);
                }
                else
                {
                    _logger.LogInformation("Пользователь не найден");
                    return Ok("Пользователь не найден");
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(_logger);
            }
        }

        [Route("create/account")]
        [HttpPost]
        public async Task<ActionResult<Account>> CreateAccount([FromBody] AccountViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос CreateAccount получен");

                // Маппим UserViewModel в User

                var result = await _userService.CreateAccount(model);

                //await _db.AddAsync(result);
                //await _db.SaveChangesAsync();

                _logger.LogInformation("Запрос CreateAccount выполнен");


                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }

        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<User>> CreateAccount([FromBody] UserViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос получен");
               
                // Маппим UserViewModel в User
               
                //var map = AutomapperUtil<UserViewModel, User>.Map(model);
                //var result = await _userService.CreateAccount(map);
                

                //await _db.AddAsync(result);
                //await _db.SaveChangesAsync();

                _logger.LogInformation("Запрос CreateAccount выполнен");


                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] UserViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос UpdateUser получен");
                
                var search = _db.User.FirstOrDefault(u => u.Id == id);
                if (search != null)
                {
                     await _userService.UpdateUser(model);

                    _logger.LogInformation("Запрос UpdateUser выполнен");

                    return Ok();
                }
                return BadRequest();

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                _logger.LogInformation("Запрос DeleteUser получен");

                var search = await _db.User.FirstOrDefaultAsync(u => u.Id == id);
                
                if (search != null) 
                {
                    _logger.LogInformation("Запрос DeleteUser выполнен");
                    var result = _userService.DeleteUserAsync(id);
                    await _db.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest("Пользователь не найден");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

    }
}
