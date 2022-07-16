using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoTask.Models;
using ToDoTaskServer.Models.Entity;
using ToDoTaskServer.Models.ViewModel;

namespace ToDoTask.Controllers
{
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

        [Route("CreateUser")]
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] UserViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                // Маппим UserViewModel в User
                var config = new MapperConfiguration(cfg => cfg.CreateMap<UserViewModel, User>());
                var mapper = new Mapper(config);
                var result = mapper.Map<User>(model);
                _db.Add(result);
                _db.SaveChanges();

                _logger.LogInformation("Запрос обработан и отправлен");

                return Ok();

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

    }
    //[Route("DeleteUser")]
    //[HttpDelete]
    //public async Task<IActionResult> DeleteUser(int id)
    //{
    //    try
    //    {
    //        _logger.LogInformation("Запрос получен");

    //        var search = _db.User.FirstOrDefault(u => u.Id == id);
    //        _logger.LogInformation("Запрос обработан");
    //        if (search == null) Ok("Пользователь не найден");

    //        var result = _db.User.Remove(search);
    //        _db.SaveChanges();

    //        return Ok();
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex.Message);

    //        return BadRequest(ex.Message);
    //    }
    //}
}
