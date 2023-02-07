using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly ILogger<TodoController> _logger;
        private ApplicationContext _db;
        private ITodoServices _todoServices;

        public TodoController(ApplicationContext db, ILogger<TodoController> logger, ITodoServices todoServices)
        {
            _db = db;
            _logger = logger;
            _todoServices = todoServices;
        }

        [Route("view")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> ViewTask()
        {
            try
            {
                //TODO: исправить эту залупу
                _logger.LogInformation("Запрос ViewTask получен");
                var result = _db.Todo
                    .Include(t => t.UserTodo)
                    .ThenInclude(tu => tu.User);


                _logger.LogInformation("Запрос ViewTask выполнен");
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
        public async Task<ActionResult<Todo>> CreateTask([FromBody] TodoViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос CreateTask получен");

                var map = AutomapperUtil<TodoViewModel, Todo>.Map(model);

                var result = _todoServices.CreateTodo(map);

                _logger.LogInformation("Запрос CreateTask выполнен");

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
        public async Task<ActionResult<Todo>> UpdateTask([FromBody] TodoViewModel model)
        {
            try
            {

                _logger.LogInformation("Запрос UpdateTask получен");

                var todo = AutomapperUtil<TodoViewModel, Todo>.Map(model);

                var result = await _todoServices.UpdateTodo(todo);

                _logger.LogInformation("Запрос UpdateTask выполнен");

                return Ok(result);


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("add/user")]
        public async Task<ActionResult<UserTodo>> AddUserTodo([FromBody]UserTodoViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос AddUserTodo получен");

                var map = AutomapperUtil<UserTodoViewModel, UserTodo>.Map(model);
                var result = await _todoServices.AddUser(map);

                _logger.LogInformation("Запрос AddUserTodo выполнен");


                return Ok(result);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/user")]
        public async Task<ActionResult<UserTodo>> DeleteUserTodo([FromBody] UserTodoViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос DeleteUserTodo получен");

                var map = AutomapperUtil<UserTodoViewModel, UserTodo>.Map(model);
                var result = await _todoServices.DeleteUser(map);

                _logger.LogInformation("Запрос DeleteUserTodo выполнен");

                return Ok(result);


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                _logger.LogInformation("Запрос DeleteTask получен");

                var result = await _todoServices.DeleteTodo(id);

                _logger.LogInformation("Запрос обработан");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}
