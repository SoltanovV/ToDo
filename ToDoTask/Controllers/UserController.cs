using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ToDoTask.Models;
using ToDoTaskServer.Models.Entity;
using ToDoTaskServer.Models.ViewModel;

namespace ASPBackend.Controllers
{
    [Route("api/UserController")]
    [ApiController]
    [EnableCors("AllowAllOrigin")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        private ApplicationContext _db;
        public UserController(ApplicationContext db, ILogger<UserController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [Route("ViewAllUser")]
        [HttpGet]
        public async Task<IActionResult> ViewAllUser()
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                return Ok(_db.User);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(_logger);
            }
        }

        [Route("ViewAllAccount")]
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

        [Route("ViewUser")]
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

        
        [Route("CreateAccount")]
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
        [Route("UpdateUser")]
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

        [Route("DeleteUser")]
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
