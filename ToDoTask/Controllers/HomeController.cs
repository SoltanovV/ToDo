using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoTask.Models;

namespace ToDoTask.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await db.User.ToListAsync());
        }

        /// <summary>
        /// Отправка представления
        /// </summary>
        /// <returns></returns>
        [Route("Create")]
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
            db.User.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
