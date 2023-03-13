using Aspbackend.Models.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ASPBackend.Controllers ;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserServices _userService;
        private readonly IMapper _mapper;
        private readonly ApplicationContext _db;
        private readonly JWTAuthenticationSettings _jwtAuthenticationSettings;

        public UserController(ApplicationContext db, ILogger<UserController> logger,
            IUserServices userService, IMapper mapper, IOptions<JWTAuthenticationSettings> jwtAuthenticationSettings)
        {
            _db = db;
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
            _jwtAuthenticationSettings = jwtAuthenticationSettings.Value;
        }

        [HttpGet]
        [Route("view")]
        public async Task<IActionResult> ViewAllUserAsync()
        {
            _logger.LogInformation("Запрос получен");
            var result = await _db.Account
                .Include(a => a.User)
                .Include(a => a.UserTodo)
                .ThenInclude(ut => ut.Todo)
                .AsNoTracking()
                .ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<UserRegistrationResponce>> CreateAccountAsync(UserRegistrationRequest request)
        {
            _logger.LogInformation("Запрос получен CreateAccountAsync получен");

            var user = _mapper.Map<User>(request);
            var account = _mapper.Map<Account>(request);

            user.Account = account;

            var result = await _userService.CreateAccountAsync(user);

            _logger.LogInformation("Запрос AuthorizationAsync обработан");

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("login")]
        public async Task<ActionResult<UserAuthorizationResponce>> AuthorizationAsync()
        {
            _logger.LogInformation("Запрос AuthorizationAsync получен");

            var userId = Convert.ToInt32(User.FindFirstValue("Id"));

            var result = await _userService.AuthorizationAccountAsync(userId);

            var responce = _mapper.Map<UserAuthorizationResponce>(result);

            _logger.LogInformation("Запрос AuthorizationAsync обработан");

            return Ok(responce);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<UserAuthorizationResponce>> LogInAsync(
            [FromBody] UserAuthorizationRequest request)
        {
            _logger.LogInformation("Запрос LogInAsync получен");

            var user = _mapper.Map<User>(request);
            var result = await _userService.AuthorizationAccountAsync(user);

            var responce = _mapper.Map<UserAuthorizationResponce>(result);

            var authenticationOptions = _jwtAuthenticationSettings;

            var token = new JwtSecurityToken(
                authenticationOptions.Issuer,
                authenticationOptions.Audience,
                new List<Claim>
                {
                    new("Id", result.Id.ToString()),
                    new(JwtRegisteredClaimNames.Name, result.Name)
                },
                expires: DateTime.Now.AddSeconds(authenticationOptions.TokenLifetime),
                signingCredentials: new SigningCredentials(authenticationOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));

            var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);

            responce.Token = generatedToken;

            _logger.LogInformation("Запрос LogInAsync обработан");

            return Ok(responce);
        }

        [HttpGet]
        [Route("id={id}")]
        public async Task<IActionResult> ViewUserAsync(int id)
        {
            _logger.LogInformation("Запрос ViewUserAsync получен");

            var result = await _db.Account
                .Where(u => u.Id == id)
                .Include(u => u.UserTodo)!
                .ThenInclude(ut => ut.Todo)
                .FirstOrDefaultAsync();

            if (result is not null)
            {
                _logger.LogInformation("Запрос ViewUserAsync выполнен");
                return Ok(result);
            }
            else
            {
                _logger.LogInformation("Пользователь не найден");
                return BadRequest("Пользователь не найден");
            }
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<UserResponce>> UpdateAccountAsync([FromBody] UserRequest request)
        {
            _logger.LogInformation("Запрос UpdateAccountAsync получен");

            var map = _mapper.Map<User>(request);

            var result = await _userService.UpdateUserAsync(map);

            var responce = _mapper.Map<UserResponce>(result);

            _logger.LogInformation("Запрос UpdateAccountAsync выполнен");


            return Ok(responce);
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