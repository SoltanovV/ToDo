using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoTask.Models;
using ToDoTaskServer.Models.Entity;
using ToDoTaskServer.Models.ViewModel;

namespace ASPBackend.Controllers
{
    [EnableCors("AllowAllOrigin")]
    [Route("api/UserController")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        private ApplicationContext _db;
        public UserController(ApplicationContext db, ILogger<UserController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [Route("viewAllUser")]
        [HttpGet]
        public async Task<IActionResult> ViewAllUser()
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                var result = _db.User.Include(p => p.Project).Include(t => t.Todo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(_logger);
            }
        }

        [Route("viewAll/Account")]
        [HttpGet]
        public async Task<IActionResult> ViewAllAccount()
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                return Ok(_db.Account);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(_logger);
            }
        }

        [Route("viewUser")]
        [HttpGet]
        public async Task<IActionResult> ViewUser(/*int id,*/ string name)
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                var result = _db.User.FirstOrDefault(u => u.Name == name);

                _logger.LogInformation("Запрос выполнен");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(_logger);
            }
        }

        
        [Route("create/Account")]
        [HttpPost]
        public async Task<ActionResult<Account>> CreateAccount([FromBody] AccountViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                // Маппим UserViewModel в User
                var config = new MapperConfiguration(cfg => cfg.CreateMap<AccountViewModel, Account>().ForMember("UserId", opt => opt.MapFrom(a => a.UserId)));
                var mapper = new Mapper(config);
                var result = mapper.Map<Account>(model);
                _db.Add(result);
                _db.SaveChanges();

                _logger.LogInformation("Запрос обработан и отправлен");

                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("update/User")]
        public async Task<IActionResult> UpdateUser(int id, string name, string email)
        {
            try
            {
                _logger.LogInformation("Запрос получен");

                var search = _db.User.FirstOrDefault(u => u.Id == id);
                //var search = _db.User.FirstOrDefault(u => u.Id == id);
                if (search != null)
                {
                    //TODO: *использовать маппре

                        search.Name = name;
                        search.Email = email;

                    _db.User.Update(search);
                    _db.SaveChanges();

                    return Ok(search);
                }
                return BadRequest();

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("delete/User")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                _logger.LogInformation("Запрос получен");

                var search = _db.User.FirstOrDefault(u => u.Id == id);
                _logger.LogInformation("Запрос обработан");
                if (search == null) Ok("Пользователь не найден");

                var result = _db.User.Remove(search);
                _db.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

    }
}
