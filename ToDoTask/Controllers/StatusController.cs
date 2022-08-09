using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoTask.Models;
using ToDoTaskServer.Models.Entity;
using ToDoTaskServer.Models.ViewModel;
using ToDoTaskServer.ViewModel.ViewModel;

namespace ASPBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private ApplicationContext _db;

        public StatusController(ILogger<ProjectController> logger, ApplicationContext db)
        {
            _logger = logger;
            _db = db;
        }

        [Route("view")]
        [HttpGet]
        public async Task<IActionResult> ViewPeroject()
        {
            try
            {
                _logger.LogInformation("Запрос получен");

                return Ok(_db.Status);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<Status>> CreateStatus([FromBody]StatusViewModel status)
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                var config = new MapperConfiguration(cfg => cfg.CreateMap<StatusViewModel, Status>());
                var mapper = new Mapper(config);
                var result = mapper.Map<Status>(status);

                _db.Status.Add(result);
                _db.SaveChanges();

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
