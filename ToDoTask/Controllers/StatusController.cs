using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoTask.Models;
using AspBackend.Models.Entity;
using AspBackend.Models.ViewModel;
using AspBackend.ViewModel.ViewModel;
using AspBackend.Utilities;

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
                _logger.LogInformation("Запрос ViewTodo получен");

                var result = _db.Status
                    .Include(s => s.Todo)
                    .ToList();

                _logger.LogInformation("Запрос ViewTodo обработна");
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
        public async Task<ActionResult<Status>> CreateStatus([FromBody]StatusViewModel model)
        {
            try
            {
                _logger.LogInformation("Запрос CreateStatus получен");

                var result = AutomapperUtil<StatusViewModel, Status>.Map(model);

                await _db.Status.AddAsync(result);
                await _db.SaveChangesAsync();
                _logger.LogInformation("Запрос CreateStatus выполнен");

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
