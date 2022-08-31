using AspBackend.Models.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspBackend.Models.Entity;
using ToDoTask.Models;
using AspBackend.Utilities;

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
                _logger.LogInformation("Запрос ViewProject получен");

                var result = _db.Project
                    .Include(p => p.ProjectTodo)
                    .ThenInclude(pt => pt.Todo)
                    .Include(u => u.UserProject)
                    .ThenInclude(u => u.User);
                    
                _logger.LogInformation("Запрос ViewProject выполнен");

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
                //var config = new MapperConfiguration(cfg => cfg.CreateMap<ProjectViewModel, Project>());
                //var mapper = new Mapper(config);
                //var result = mapper.Map<Project>(model);
                var result = AutomapperUtil< ProjectViewModel, Project>.Map(model);

                await _db.Project.AddAsync(result);
                await _db.SaveChangesAsync();

                _logger.LogInformation("Запрос CreateProject выполнен");

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
                _logger.LogInformation("Запрос AddUserProject получен");
                var userAdd = _db.User.FirstOrDefault(p => p.Id == model.UserId);
                var project = _db.Project.FirstOrDefault(p => p.Id == model.ProjectId);

                var result = AutomapperUtil<UserProjectViewModel, UserProject>.Map(model);

                if (project != null & userAdd != null)
                {
                    await _db.UsersProjects.AddAsync(result);
                    await _db.SaveChangesAsync();

                    _logger.LogInformation("Запрос AddUserProject выполнен");

                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Проект или пользователь не найден");

                    return BadRequest("Проект или пользователь не найден");

                }
               
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
                _logger.LogInformation("Запрос DeleteUserProject получен");

                var userDelete = _db.UsersProjects.FirstOrDefault(p => p.UserId == userId);
                var project = _db.Project.FirstOrDefault(p => p.Id == projectId);

                if (project != null & userDelete != null)
                {
                    _db.UsersProjects.Remove(userDelete);
                    _db.SaveChanges();
                    _logger.LogInformation("Запрос DeleteUserProject выполнен");

                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Пользователь не найден");

                    return BadRequest("Проект не найден");
                }
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
                _logger.LogInformation("Запрос UpdateProject получен");
                var project = await _db.Project.FirstOrDefaultAsync(p => p.Id == id);
                if (project != null)
                {
                    project.Name = model.Name;
                    _logger.LogInformation("Запрос UpdateProject выполнен");
                    await _db.SaveChangesAsync();

                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Проект не найден");

                    return BadRequest("Проект не найден");
                }
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
                _logger.LogInformation("Запрос DeleteProject получен");

                var search = await _db.Project.FirstOrDefaultAsync(t => t.Id == id);

                if (search != null) 
                {
                    var result = _db.Project.Remove(search);

                    _logger.LogInformation("Запрос DeleteProject выполнен");

                    await _db.SaveChangesAsync();

                    return Ok();
                }
                else
                { 
                    return Ok("Задача не найдена");

                    _logger.LogInformation("Задача не найдена");
                }
                              
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}
