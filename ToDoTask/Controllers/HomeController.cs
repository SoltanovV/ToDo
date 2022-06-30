using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoTask.Models;

namespace ToDoTask.Controllers
{
    [Route("{controller}")]
    public class HomeController : Controller
    {
        private ApplicationContext _db;
        public HomeController(ApplicationContext context)
        {
            _db = context;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _db.User.ToListAsync());
        }

        /// <summary>
        /// Отправка представления
        /// </summary>
        /// <returns></returns>
        [Route("Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Добавление новых пользователей
        /// и переадресация по нажатию кнопки на страницу Index
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            _db.User.Add(user);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
