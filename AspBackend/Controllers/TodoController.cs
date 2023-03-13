using Microsoft.AspNetCore.Mvc;

namespace ASPBackend.Controllers ;

    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly ILogger<TodoController> _logger;
        private readonly ITodoServices _todoServices;
        private readonly IMapper _mapper;
        private readonly ApplicationContext _db;

        public TodoController(ApplicationContext db, ILogger<TodoController> logger, ITodoServices todoServices,
            IMapper mapper)
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
            _logger.LogInformation("Запрос GetTodoAsync получен");

            var todo = await _db.Todo.Include(t => t.Accounts).ToListAsync();

            _logger.LogInformation("Запрос GetTodoAsync выполнен");

            return Ok(todo);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<CreateTodoResponce>> CreateTodoAsync(CreateTodoRequest request)
        {
            _logger.LogInformation("Запрос CreateTodoAsync получен");

            var todo = _mapper.Map<Todo>(request);
            var status = _mapper.Map<Status>(request);
            var priority = _mapper.Map<Priority>(request);

            todo.Status = status;
            todo.Priority = priority;

            var result = await _todoServices.CreateTodoAsync(todo);

            _logger.LogInformation("Запрос CreateTodoAsync выполнен");

            return Ok(result);
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<UpdateTodoResponce>> UpdateTodoAsync([FromBody] UpdateTodoRequest request)
        {
            _logger.LogInformation("Запрос UpdateTodoAsync получен");

            var todo = _mapper.Map<Todo>(request);

            var result = await _todoServices.UpdateTodoAsync(todo);

            _logger.LogInformation("Запрос UpdateTodoAsync выполнен");

            return Ok(result);
        }


        [HttpPost]
        [Route("add/user")]
        public async Task<ActionResult<UserTodoResponce>> AddUserTodoAsync([FromBody] UserTodoRequest request)
        {
            _logger.LogInformation("Запрос AddUserTodoAsync получен");

            var map = _mapper.Map<UserTodo>(request);
            var result = await _todoServices.AddUserAsync(map);

            _logger.LogInformation("Запрос AddUserTodoAsync выполнен");


            return Ok(result);
        }

        [HttpPost]
        [Route("delete/user")]
        public async Task<ActionResult<UserTodoResponce>> DeleteUserTodoAsync([FromBody] UserTodoRequest request)
        {
            _logger.LogInformation("Запрос DeleteUserTodoAsync получен");

            var map = _mapper.Map<UserTodo>(request);
            var result = await _todoServices.DeleteUserAsync(map);

            _logger.LogInformation("Запрос DeleteUserTodoAsync выполнен");

            return Ok(result);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteTodoAsync(int id)
        {
            _logger.LogInformation("Запрос DeleteTodoAsync получен");

            var result = await _todoServices.DeleteTodoAsync(id);

            _logger.LogInformation("Запрос DeleteTodoAsync обработан");

            return Ok(result);
        }
    }