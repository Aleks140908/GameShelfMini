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
    }
}
