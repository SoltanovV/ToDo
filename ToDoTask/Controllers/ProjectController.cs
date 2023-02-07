using AspBackend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ToDoTask.Models;
using AspBackend.Utilities;
using AspBackend.Services.Interfaces;

namespace AspBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private ApplicationContext _db;
        private IProjectServices _projectSerices;

        public ProjectController(ILogger<ProjectController> logger, ApplicationContext db, IProjectServices projectSerices)
        {
            _logger = logger;
            _db = db;
            _projectSerices = projectSerices;
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

                var map = AutomapperUtil< ProjectViewModel, Project>.Map(model);
                var result = await _projectSerices.CreateProjectAsync(map);

                _logger.LogInformation("Запрос CreateProject выполнен");

                return Ok();

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
            
        [HttpPut]
        [Route("update/{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, [FromBody] ProjectViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос UpdateProject получен");

                var map = AutomapperUtil<ProjectViewModel, Project>.Map(model);
                var result = await _projectSerices.UpdateProjectAsync(map);

                _logger.LogInformation("Запрос UpdateProject выполнен");
                    

                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<ActionResult< Project>> DeleteProject(int id)
        {
            try
            {
                _logger.LogInformation("Запрос DeleteProject получен");

                 var result = await _projectSerices.DeleteProjectAsync(id);

                _logger.LogInformation("Запрос DeleteProject выполнен");

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
        public async Task<ActionResult<UserProject>> AddUserProject([FromBody] UserProjectViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос AddUserProject получен");

                var map = AutomapperUtil<UserProjectViewModel, UserProject>.Map(model);
                var result = await _projectSerices.AddUserProjectAsync(map);

                _logger.LogInformation("Запрос AddUserProject выполнен");

                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/user")]
        public async Task<ActionResult<UserProject>> DeleteUserProject(UserProjectViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос DeleteUserProject получен");

                var map = AutomapperUtil<UserProjectViewModel, UserProject>.Map(model);
                var result = await _projectSerices.DeleteUserProjectAsync(map);

                _logger.LogInformation("Запрос DeleteUserProject выполнен");

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
