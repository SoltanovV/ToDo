using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoTask.Models;
using ToDoTaskServer.Models.Entity;
using ToDoTaskServer.Models.ViewModel;

namespace ASPBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly ILogger<TodoController> _logger;
        private ApplicationContext _db;

        public TodoController(ApplicationContext db, ILogger<TodoController> logger)
        {
            _db = db;
            _logger = logger;
        }
        [Route("priority")]
        [HttpGet]
        public async Task<IActionResult> ViewPriority()
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                var result = _db.Todo.Include(t => t.Priority);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(_logger);
            }
        }

        [Route("status")]
        [HttpGet]
        public async Task<IActionResult> ViewStatus()
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                var result = _db.Todo.Include(t => t.Status);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(_logger);
            }
        }

        [Route("view")]
        [HttpGet]
        public async Task<IActionResult> ViewAllTask()
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                return Ok(_db.Todo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(_logger);
            }
        }


        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTask([FromBody] TodoViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос получен");

                var config = new MapperConfiguration(cfg => cfg.CreateMap<TodoViewModel, Todo>());
                var mapper = new Mapper(config);
                var result = mapper.Map<Todo>(model);
                //todo.CreateUser.Projects.
                _db.Add(result);
                _db.SaveChanges();
                _logger.LogInformation("Запрос обработан и отправлен");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(_logger);
            }
        }

        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateTask(int id, string name, string description, int userId, DateTime startDate, DateTime endDate, int statusId, int priorityId)
        {
            try
            {
                _logger.LogInformation("Запрос получен");

                var search = _db.Todo.FirstOrDefault(t => t.Id == id);
                if(search != null)
                {
                    search.NameTask = name;
                    search.Description = description;
                    //search.UserId = userId;
                    search.StartData = startDate;
                    search.EndData = endDate;
                    //search.StatusId = statusId;
                    //search.PriorityId = priorityId;
                    
                    

                    _db.Todo.Update(search);
                    _db.SaveChanges();

                    return Ok(search);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                _logger.LogInformation("Запрос получен");

                var search = _db.Todo.FirstOrDefault(t => t.Id == id);
                _logger.LogInformation("Запрос обработан");
                if (search == null) Ok("Задача не найдена");

                var result = _db.Todo.Remove(search);
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
