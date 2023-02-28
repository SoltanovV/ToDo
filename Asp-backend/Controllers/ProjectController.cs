using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Models.Responce;

namespace AspBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectServices _projectSerices;
        private readonly IMapper _mapper;
        private readonly ApplicationContext _db;

        public ProjectController(ILogger<ProjectController> logger, ApplicationContext db, 
                                 IProjectServices projectSerices, IMapper mapper)
        {
            _projectSerices = projectSerices;
            _logger = logger;
            _mapper = mapper;
            _db = db;
        }

        [HttpGet]
        [Route("view")]
        public async Task<IActionResult> GetProjectAsync()
        {
            try
            {
                _logger.LogInformation("Запрос ViewProject получен");

                var result = await _db.Project
                    .Include(p => p.UserProject)
                    .ThenInclude(pt => pt.Account)
                    .ToListAsync();

                _logger.LogInformation("Запрос ViewProject выполнен");

                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ProjectResponce>> CreateProjectAsync([FromBody] ProjectRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос получен");

                var map = _mapper.Map<Project>(request);
                var result = await _projectSerices.CreateProjectAsync(map);

                _logger.LogInformation("Запрос CreateProject выполнен");

                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<ProjectResponce>> UpdateProjectAsync([FromBody] ProjectRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос UpdateProject получен");

                var map = _mapper.Map<Project>(request);

                var result = await _projectSerices.UpdateProjectAsync(map);

                _logger.LogInformation("Запрос UpdateProject выполнен");


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
        public async Task<ActionResult<Project>> DeleteProjectAsync(int id)
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
        public async Task<ActionResult<ProjectUserResponce>> AddUserProjectAsync([FromBody] ProjectUserRequest model)
        {
            try
            {
                _logger.LogInformation("Запрос AddUserProject получен");

                var map = _mapper.Map<UserProject>(model);
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

        [HttpPost]
        [Route("delete/user")]
        public async Task<ActionResult<ProjectUserResponce>> DeleteUserProjectAsync([FromBody] ProjectUserRequest model)
        {
            try
            {
                _logger.LogInformation("Запрос DeleteUserProject получен");

                var map = _mapper.Map<UserProject>(model);
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
