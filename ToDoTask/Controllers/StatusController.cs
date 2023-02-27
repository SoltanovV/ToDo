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

        [HttpGet]
        [Route("view")]
        public async Task<IActionResult> GetStatusTaskAsync()
        {
            try
            {
                _logger.LogInformation("Запрос ViewTodo получен");

                var result = await _db.Status
                    .Include(s => s.Todo)
                    .ToListAsync();

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
