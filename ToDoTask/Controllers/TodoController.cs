using Microsoft.AspNetCore.Mvc;

namespace ASPBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly ILogger<TodoController> _logger;
        private readonly ITodoServices _todoServices;
        private readonly IMapper _mapper;
        private readonly ApplicationContext _db;

        public TodoController(ApplicationContext db, ILogger<TodoController> logger, ITodoServices todoServices, IMapper mapper)
        {
            _db = db;
            _logger = logger;
            _todoServices = todoServices;
            _mapper = mapper;
        }

        [Route("get")]
        [HttpGet]
        public async Task<ActionResult<Todo>> TodoGetAsync()
        {
            try
            {
                _logger.LogInformation("Запрос TodoGet получен");

                var todo = _db.Todo;

                _logger.LogInformation("Запрос TodoCreate выполнен");

                return Ok(todo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(_logger);
            }
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<CreateTodoResponce>> TodoCreateAsync(CreateTodoRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос TodoCreate получен");

                var todo = _mapper.Map<Todo>(request);

                var status = _mapper.Map<Status>(request);

                var priority = _mapper.Map<Priority>(request);
                
                todo.Status = status;
                todo.Priority= priority;

                var result = await _todoServices.CreateTodoAsync(todo);

                _logger.LogInformation("Запрос TodoCreate выполнен");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(_logger);
            }
        }

        [Route("update")]
        [HttpPost]
        public async Task<ActionResult<UpdateTodoResponce>> UpdateTask([FromBody] UpdateTodoRequest request)
        {
            try
            {

                _logger.LogInformation("Запрос UpdateTask получен");

                var todo = _mapper.Map<Todo>(request);

                var result = await _todoServices.UpdateTodoAsync(todo);

                _logger.LogInformation("Запрос UpdateTask выполнен");

                return Ok(result);


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }


        //[HttpPost]
        //[Route("add/user")]
        //public async Task<ActionResult<UserTodo>> AddUserTodo([FromBody]UserTodoViewModel model)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Запрос AddUserTodo получен");

        //        var map = AutomapperUtil<UserTodoViewModel, UserTodo>.Map(model);
        //        var result = await _todoServices.AddUser(map);

        //        _logger.LogInformation("Запрос AddUserTodo выполнен");


        //        return Ok(result);

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpDelete]
        //[Route("delete/user")]
        //public async Task<ActionResult<UserTodo>> DeleteUserTodo([FromBody] UserTodoViewModel model)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Запрос DeleteUserTodo получен");

        //        var map = AutomapperUtil<UserTodoViewModel, UserTodo>.Map(model);
        //        var result = await _todoServices.DeleteUser(map);

        //        _logger.LogInformation("Запрос DeleteUserTodo выполнен");

        //        return Ok(result);


        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[Route("delete/{id}")]
        //[HttpDelete]
        //public async Task<IActionResult> DeleteTask(int id)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Запрос DeleteTask получен");

        //        var result = await _todoServices.DeleteTodo(id);

        //        _logger.LogInformation("Запрос обработан");

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);

        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
