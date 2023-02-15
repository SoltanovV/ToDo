using Microsoft.AspNetCore.Mvc;

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
        
    }
}
