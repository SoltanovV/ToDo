using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoTask.Models;
using AspBackend.Models.Entity;
using AspBackend.Models.ViewModel;
using AspBackend.ViewModel.ViewModel;

namespace ASPBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<StatusController> _logger;
        private ApplicationContext _db;

        public StatusController(ILogger<StatusController> logger, ApplicationContext db)
        {
            _logger = logger;
            _db = db;
        }

        [Route("view")]
        [HttpGet]
        public async Task<IActionResult> ViewTodo()
        {
            try
            {
                _logger.LogInformation("Запрос получен");

                var result = _db.Status
                    .Include(s => s.Todo)
                    .ToList();

                _logger.LogInformation("Запрос обработна");
                return Ok(result);
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
