using ASPbackend.Models.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoTask.Models;
using AspBackend.Models.Entity;
using AspBackend.Models.ViewModel;

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
                return Ok("Успешно");
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
                return Ok("Успешно");
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
                var result = _db.Todo
                    .Include(t => t.UserTodo)
                    .ThenInclude(tu => tu.User)
                    .Include(t => t.Status)
                    .Include(t => t.Priority)
                    .Include(t => t.ProjectTodo)
                    .ThenInclude(tp => tp.Project)
                    .ToList();
                return Ok("Успешно");
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

                var config = new MapperConfiguration(cfg => cfg
                                                               .CreateMap<TodoViewModel, Todo>()
                                                                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)));
                var mapper = new Mapper(config);
                var result = mapper.Map<Todo>(model);

                _db.Add(result);
                await _db.SaveChangesAsync();
                _logger.LogInformation("Запрос обработан и отправлен");

                return Ok("Успешно");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(_logger);
            }
        }

        //TODO: попробывать переделать все красиво 
        [Route("update/{id}")]
        [HttpPut]
        public async Task<ActionResult<Todo>> UpdateTask(int id, [FromBody]TodoViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос получен");

                var searchTodo = _db.Todo.Where(t => t.Id == id).FirstOrDefault();

                if (searchTodo != null)    
                {
                    //var config = new MapperConfiguration(cfg => cfg.CreateMap<TodoViewModel, Todo>());
                    //var mapper = new Mapper(config);
                    //var result = mapper.Map<Todo>(model);

                    searchTodo.NameTask = model.NameTask;
                    searchTodo.Description = model.Description;
                    searchTodo.EndData = model.EndData;
                    searchTodo.StatusId = model.StatusId;
                    searchTodo.PriorityId = model.PriorityId;

                    _db.Todo.Update(searchTodo);
                    _db.SaveChanges();

                    _logger.LogInformation("Запрос обработан и отправлен");

                    return Ok("Успешно");
                }
                _logger.LogInformation("Ошибка пользователь не найден");
                return BadRequest("Ошибка пользователь не найден");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // [HttpPut]
        // [Route("update/user")]
        // public async Task<IActionResult> UpdateUserTodo(int userId, [FromBody]TodoViewModel model)
        // {
        //     try 
        //     {
        //         var user = _db.UsersTodos.FirstOrDefault(ut => ut.UserId.Equals(userId));

        //         if(user != null)
        //         {
        //             _db.UsersTodos.Remove(user);
        //             _db.SaveChanges();

        //             user.UserId = model.UserId;
        //             _db.UsersTodos.Add(user);
        //             _db.SaveChanges();

        //             return Ok();
        //         }
        //         return BadRequest();
        //     }
        //     catch(Exception ex)
        //     {
        //         _logger.LogError(ex.Message);
        //         return BadRequest(ex.Message);
        //     }
        // }
        
        [HttpPost]
        [Route("add/user")]
        public async Task<ActionResult<UserTodo>> AddUserTodo([FromBody]UserTodoViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                var userAdd = _db.User.FirstOrDefault(t => t.Id == model.UserId);
                var todo = _db.Todo.FirstOrDefault(t => t.Id == model.TodoId);
                var config = new MapperConfiguration(cfg => cfg.CreateMap<UserTodoViewModel, UserTodo>());
                var mapper = new Mapper(config);
                var result = mapper.Map<UserTodo>(model);

                if (todo != null & userAdd != null)
                {
                    _db.UsersTodos.Add(result);
                    _db.SaveChanges();

                    _logger.LogInformation("Запрос обработан и отправлен");

                    return Ok();
                }
                _logger.LogInformation("Пользователь не найден");

                return BadRequest("Задача не найдена");
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

                return Ok("Успешно");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}
