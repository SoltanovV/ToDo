using AspBackend.Models.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspBackend.Models.Entity;
using ToDoTask.Models;


namespace AspBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private ApplicationContext _db;

        public ProjectController(ILogger<ProjectController> logger, ApplicationContext db)
        {
            _logger = logger;
            _db = db;
        }
        [HttpGet]
        [Route("view")]
        public async Task<IActionResult> ViewProject()
        {
            try
            {
                _logger.LogInformation("Запрос получен");

                var result = _db.Project
                    .Include(p => p.ProjectTodo)
                    .ThenInclude(pt => pt.Todo)
                    .Include(u => u.UserProject)
                    .ThenInclude(u => u.User).ToList();
                    
                _logger.LogInformation("Запрос обработан");

                return Ok(result);
                
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Project>> CreateProject([FromBody] ProjectViewModel model) 
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ProjectViewModel, Project>());
                var mapper = new Mapper(config);
                var result = mapper.Map<Project>(model);

                _db.Project.Add(result);
                _db.SaveChanges();

                _logger.LogInformation("Запрос выполнен и отправлен");

                return Ok();

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("add/user")]
        public async Task<ActionResult<UserProject>> AddUserProject([FromBody] UserProjectViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                var userAdd = _db.User.FirstOrDefault(p => p.Id == model.UserId);
                var project = _db.Project.FirstOrDefault(p => p.Id == model.ProjectId);
                var config = new MapperConfiguration(cfg => cfg.CreateMap<UserProjectViewModel, UserProject>());
                var mapper = new Mapper(config);
                var result = mapper.Map<UserProject>(model);

                if (project != null & userAdd != null)
                {
                    _db.UsersProjects.Add(result);
                    _db.SaveChanges();

                    _logger.LogInformation("Запрос обработан и отправлен");

                    return Ok();
                }
                _logger.LogInformation("Проект или пользователь не найден");

                return BadRequest("Проект или пользователь не найден");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/user")]
        public async Task<IActionResult> DeleteUserProject(int userId, int projectId)
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                var userDelete = _db.UsersProjects.FirstOrDefault(p => p.UserId == userId);
                var project = _db.Project.FirstOrDefault(p => p.Id == projectId);
                if (project != null & userDelete != null)
                {
                    _db.UsersProjects.Remove(userDelete);
                    _db.SaveChanges();
                    _logger.LogInformation("Запрос обработан и отправлен");

                    return Ok();
                }
                _logger.LogInformation("Пользователь не найден");

                return BadRequest("Проект не найден");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] ProjectViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                var project = _db.Project.FirstOrDefault(p => p.Id == id);
                if (project != null)
                {
                    project.Name = model.Name;
                    _logger.LogInformation("Запрос обработан и отправлен");
                    _db.SaveChanges();

                    return Ok();
                }
                _logger.LogInformation("Проект не найден");

                return BadRequest("Проект не найден");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProject(int id)
        {
            try
            {
                _logger.LogInformation("Запрос получен");

                var search = _db.Project.FirstOrDefault(t => t.Id == id);

                if (search == null) return Ok("Задача не найдена");

                _logger.LogInformation("Запрос обработан и выполнен");


                var result = _db.Project.Remove(search);

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
