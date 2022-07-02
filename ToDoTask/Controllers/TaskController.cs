using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoTask.Models;
using ToDoTask.Models.Task;
using ToDoTaskServer.Models.ViewModes;

namespace ToDoTaskServer.Controllers
{
    [Route("api/TaskController")]
    public class TaskController : Controller
    {
        private ApplicationContext _db;
        private readonly ILogger<TaskController> _logger;

        public TaskController(ApplicationContext db,ILogger<TaskController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [Route("CreateTask")]
        [HttpPost]
        public async Task<ActionResult<Task>> ViewTask([FromBody] TaskViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос получен");

                var config = new MapperConfiguration(cfg => cfg.CreateMap<TaskViewModel, Task>());
                var mapper = new Mapper(config);
                var result = mapper.Map<Task>(model);

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
