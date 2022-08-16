using ASPbackend.Models.Entity;
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
                var result = _db.Todo
                    .Include(t => t.UserTodo)
                    .ThenInclude(tu => tu.User)
                    .Include(t => t.Status)
                    .Include(t => t.Priority)
                    .Include(t => t.ProjectTodo)
                    .ThenInclude(tp => tp.Project)
                    .ToList();
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
                _logger.LogInformation("Запрос получен");

                var config = new MapperConfiguration(cfg => cfg
                                                               .CreateMap<TodoViewModel, Todo>()
                                                                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)));
                var mapper = new Mapper(config);
                var result = mapper.Map<Todo>(model);

                _db.Add(result);
                await _db.SaveChangesAsync();
                _logger.LogInformation("Запрос обработан и отправлен");

                return Ok(result);
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
        public async Task<IActionResult> UpdateTask(int id, int userId, [FromBody]TodoViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос получен");

                var searchTodo = _db.Todo.Where(t => t.Id == id).FirstOrDefault();
                var user = _db.UsersTodos.FirstOrDefault(ut => ut.UserId.Equals(userId));
                //var d = _db.User.Where(u => u.Id == userId).FirstOrDefault();

                if (searchTodo != null /*& serachUser != null*/)
                {
                    //var config = new MapperConfiguration(cfg => cfg
                    //                                               .CreateMap<TodoViewModel, Todo>()
                    //                                               .ForMember(t => t.StatusId, e => e.MapFrom(src => src.StatusId))
                    //                                               .ForPath(t => t.PriorityId, e => e.MapFrom(src => src.PriorityId))
                    //                                               /*.ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null))*/);
                    //var mapper = new Mapper(config);
                    //var result = mapper.Map<Todo>(model);
                    searchTodo.NameTask = model.NameTask;
                    searchTodo.Description = model.Description;
                    searchTodo.StartData = model.StartData;
                    searchTodo.EndData = model.EndData;
                    searchTodo.StatusId = model.StatusId;
                    searchTodo.PriorityId = model.PriorityId;

                    _db.UsersTodos.Remove(user);
                    _db.SaveChanges();

                    user.UserId = model.UserId;

                    _db.UsersTodos.Add(user);
                    _db.Update(searchTodo);
                    _db.SaveChanges();

                    return Ok();
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
