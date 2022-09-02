using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoTask.Models;
using AspBackend.Models.Entity; 
using AspBackend.Models.ViewModel;
using AspBackend.Utilities;
using AspBackend.Services.Interface;

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

        //[Route("priority")]
        //[HttpGet]
        //public async Task<IActionResult> ViewPriority()
        //{
        //    try
        //    {
        //        _logger.LogInformation("Запрос ViewPriority получен");

        //        var result = _db.Todo.Include(t => t.Priority);

        //        _logger.LogInformation("Запрос ViewPriority выполнен");

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        return BadRequest(_logger);
        //    }
        //}

        //[Route("edit/priority")]
        //[HttpPut]
        //public async Task<ActionResult<Todo>> EditPriority(int id, int priorityId)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Запрос EditPriority получен");
        //        var seacrh = _db.Todo.FirstOrDefault(t => t.Id == id);

        //        if (seacrh != null)
        //        {
                    
        //             seacrh.PriorityId = priorityId;
        //            _db.Todo.Update(seacrh);
        //            _db.SaveChanges();
        //            _logger.LogInformation("Запрос EditPriority выполнен");
        //            return Ok(seacrh);
        //        }
        //        return BadRequest("Ошибка");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        return BadRequest(_logger);
        //    }
        //}

        //[Route("edit/status")]
        //[HttpPut]
        //public async Task<ActionResult<Todo>> EditStatus(int id, int statusId)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Запрос EditStatus получен");
        //        var seacrh = _db.Todo.FirstOrDefault(t => t.Id == id);

        //        if (seacrh != null)
        //        {
        //            seacrh.StatusId = statusId;
        //            _db.Todo.Update(seacrh);
        //            _db.SaveChanges();
        //            _logger.LogInformation("Запрос EditStatus выполнен");
        //            return Ok(seacrh);
        //        }
        //        return BadRequest("Ошибка");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        return BadRequest(_logger);
        //    }
        //}

        //[Route("status")]
        //[HttpGet]
        //public async Task<IActionResult> ViewStatus()
        //{
        //    try
        //    {
        //        _logger.LogInformation("Запрос ViewStatus получен");

        //        var result = _db.Todo.Include(t => t.Status);

        //        _logger.LogInformation("Запрос ViewStatus выполнен");

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        return BadRequest(_logger);
        //    }
        //}

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
