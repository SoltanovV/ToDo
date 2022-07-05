using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoTask.Models;
using ToDoTaskServer.Models.Entity;
using ToDoTaskServer.Models.ViewModel;

namespace ToDoTaskServer.Controllers
{
    [Route("api/TaskController")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly ILogger<TaskController> _logger;
        private ApplicationContext _db;

        public TaskController(ApplicationContext db, ILogger<TaskController> logger)
        {
            _db = db;
            _logger = logger;
        }
        [Route("ViewTask")]
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


        [Route("CreateTask")]
        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTask([FromBody] TodoViewModel model, int id, )
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
    }
}
