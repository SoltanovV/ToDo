using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoTask.Models;
using ToDoTask.Models.Task;
using ToDoTaskServer.Models.ViewModel;

namespace ToDoTaskServer.Controllers
{
    [Route("api/TaskController")]
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
                return Ok(_db.TodoTask);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(_logger);
            }
        }


        [Route("CreateTask")]
        [HttpPost]
        public async Task<ActionResult<TodoTask>> CreateTask([FromBody] TaskViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос получен");

                var config = new MapperConfiguration(cfg => cfg.CreateMap<TaskViewModel, TodoTask>());
                var mapper = new Mapper(config);
                var result = mapper.Map<TodoTask>(model);

                _db.Add(result);
                _db.SaveChanges();

                _logger.LogInformation("Запрос обработан и отправлен");

                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(_logger);
            }
        } 
    }
}
