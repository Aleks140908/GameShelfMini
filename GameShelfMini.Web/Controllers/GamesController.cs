using Microsoft.AspNetCore.Mvc;

namespace GameShelfMini.Web.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
