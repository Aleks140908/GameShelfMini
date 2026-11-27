using GameShelfMini.Data.Enums;
using GameShelfMini.Services;
using GameShelfMini.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GameShelfMini.Web.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameService gameService;
        public GamesController(IGameService gameService)
        {
            this.gameService = gameService;
        }
        public async Task<IActionResult> Index()
        {
            var games = await gameService.GetAll();
            return View(games);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            string title, string developer, Platform platform, Genre genre, int releaseYear)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(developer))
            {
                ViewData["Error"] = "Заглавието и разработчикът са задължителни.";
                return View();
            }

            await gameService.Create(title.Trim(), developer.Trim(), platform, genre, releaseYear);

            return RedirectToAction(nameof(Index));
        }
    }
}
