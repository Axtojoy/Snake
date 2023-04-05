using Microsoft.AspNetCore.Mvc;
using Snake.Logic;
using Snake.Logic.Models;
using Snake.Models.Game;
using System.Drawing;
using System.Text.Json;
using static Snake.Models.Game.GameViewModel;

namespace Snake.Controllers
{
    public class GameController : Controller
    {
        private readonly GameService _gameService;

        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }
 

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Game()
        {
            var game = _gameService.GetCoordinate();
            var lines = game.Game.Select(c => new Line
            {
                Start = new Point { X = c.x1, Y = c.y1 },
                End = new Point { X = c.x2, Y = c.y2 }
            }).ToList();
            var gameModel = new GameViewModel(game) { Lines = lines };
            return View(gameModel);
            //var game = _gameService.GetCoordinate();
            //var gameModel = new GameViewModel(game);
            //return View(gameModel);

        }
        [HttpPost]
        public IActionResult GameAdd(int prevPointX, int prevPointY, int nearestPointX, int nearestPointY)
        {
             _gameService.Update(new GameDTO()
            {
                x1 = prevPointX,
                x2 = nearestPointX,
                y1 = prevPointY,
                y2 = nearestPointY
             });
            return Json(new { success = true });
        }
        [HttpPost]
        public IActionResult Reset()
        {
            _gameService.Delete();
            return Json(new { success = true });
        }
    }
}
