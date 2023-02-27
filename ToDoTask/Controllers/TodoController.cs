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
            _mapper = mapper;
            _todoServices = todoServices;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<Todo>> GetTodoAsync()
        {
            try
            {
                _logger.LogInformation("Запрос TodoGet получен");

                var todo = await _db.Todo.Include(t => t.Users).ToListAsync();

                _logger.LogInformation("Запрос TodoCreate выполнен");

                return Ok(todo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(_logger);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<CreateTodoResponce>> CreateTodoAsync(CreateTodoRequest request)
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

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<UpdateTodoResponce>> UpdateTodoAsync([FromBody] UpdateTodoRequest request)
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


        [HttpPost]
        [Route("add/user")]
        public async Task<ActionResult<UserTodoResponce>> AddUserTodoAsync([FromBody] UserTodoRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос AddUserTodo получен");

                var map = _mapper.Map<UserTodo>(request);
                var result = await _todoServices.AddUserAsync(map);

                _logger.LogInformation("Запрос AddUserTodo выполнен");


                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("delete/user")]
        public async Task<ActionResult<UserTodoResponce>> DeleteUserTodoAsync([FromBody] UserTodoRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос DeleteUserTodo получен");

                var map = _mapper.Map<UserTodo>(request );
                var result = await _todoServices.DeleteUserAsync(map);

                _logger.LogInformation("Запрос DeleteUserTodo выполнен");

                return Ok(result);


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteTodoAsync(int id)
        {
            try
            {
                _logger.LogInformation("Запрос DeleteTask получен");

                var result = await _todoServices.DeleteTodoAsync(id);

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
