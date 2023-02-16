using Microsoft.AspNetCore.Mvc;

namespace ASPBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserServices _userService;
        private readonly IMapper _mapper;
        private readonly ApplicationContext _db;

        public UserController(ApplicationContext db, ILogger<UserController> logger, 
            IUserServices userService, IMapper mapper)
        {
            _db = db;
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("view")]
        public async Task<IActionResult> ViewAllUser()
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                var result = await _db.User
                    .Include(u => u.Account)
                    .Include(u => u.UserTodo)
                    .ThenInclude( ut => ut.Todo)
                    .AsNoTracking()
                    .ToListAsync();
                              

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(_logger);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<SigInResponce>> CreateAccountAsync(SigInRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос получен CreateAccount получен");

                var user = _mapper.Map<User>(request);

                var account = _mapper.Map<Account>(request);

                user.Account = account;

                var result = await _userService.CreateAccountAsync(user);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(_logger);
            }
        }

        [HttpGet]
        [Route("view/{id}")]
        public async Task<IActionResult> ViewUser(int id)
        {
            try
            {
                _logger.LogInformation("Запрос ViewUser получен");

                var result = _db.User
                    .Where(u => u.Id == id)
                    .Include(u => u.UserTodo)
                    .ThenInclude(ut => ut.Todo)
                    .FirstOrDefault();

                if (result != null)
                {
                    _logger.LogInformation("Запрос ViewUser выполнен");
                    return Ok(result);
                }
                else
                {
                    _logger.LogInformation("Пользователь не найден");
                    return Ok("Пользователь не найден");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(_logger);
            }
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<UserResponce>> CreateAccount([FromBody] UserRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос получен");

                // Маппим UserViewModel в User

                var map = _mapper.Map<User>(request);

                var result = await _userService.UpdateUserAsync(map);

                var responce = _mapper.Map<UserResponce>(result);

                _logger.LogInformation("Запрос CreateAccount выполнен");


                return Ok(responce);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }

        }


        //[Route("delete")]
        //[HttpDelete]
        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Запрос DeleteUser получен");

        //        var search = await _db.User.FirstOrDefaultAsync(u => u.Id == id);

        //        if (search != null) 
        //        {
        //            _logger.LogInformation("Запрос DeleteUser выполнен");
        //            var result = _userService.DeleteUserAsync(id);
        //            await _db.SaveChangesAsync();
        //            return Ok();
        //        }
        //        else
        //        {
        //            return BadRequest("Пользователь не найден");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);

        //        return BadRequest(ex.Message);
        //    }
        //}

    }
}
