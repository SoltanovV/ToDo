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
    [Route("api/[controller]")]
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

        [Route("view")]
        [HttpGet]
        public async Task<IActionResult> ViewAllUser()
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                var result = _db.User
                    .Include(u => u.UserProject)
                    .ThenInclude(up => up.Project)
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
        public async Task<IActionResult> ViewAllAccount()
        {
            try
            {
                _logger.LogInformation("Запрос получен");
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
        public async Task<IActionResult> ViewUser(/*int id,*/ string name)
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                var result = _db.User.Include(u => u.Name == name);

                _logger.LogInformation("Запрос выполнен");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(_logger);
            }
        }

        
        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<Account>> CreateAccount([FromBody] AccountViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                // Маппим UserViewModel в User
                var config = new MapperConfiguration(cfg => cfg.CreateMap<AccountViewModel, Account>());
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
        [Route("update")]
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

        [Route("delete")]
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
