using GameZone.Areas.Admin.Controllers;
using GameZone.Data;
using GameZone.Models;
using GameZone.Services;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
    public class Games : Controller
    {
        private readonly IGameServices _gameServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IDeviceService _deviceService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Games(IGameServices gameServices, IDeviceService deviceService, ICategoryServices categoryServices, IWebHostEnvironment webHostEnvironment)
        {
            _gameServices = gameServices;
            _deviceService = deviceService;
            _categoryServices = categoryServices;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _gameServices.GetGames();
            return View(games);
        }
        public IActionResult AddGame()
        {
            var game = new GameVM
            {
                Devices = _deviceService.DeviceSelectList(),
                Categories = _categoryServices.CategorySelectList()
            };
            return View(game);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGame(GameVM game)
        {

            if (!ModelState.IsValid)
            {
                game.Devices = _deviceService.DeviceSelectList();
                game.Categories = _categoryServices.CategorySelectList();
                return View(game);
            }
         

            await _gameServices.AddGame(game);
            return RedirectToAction(nameof(AddGame));

        }
        public async Task<IActionResult> GameDetails(int id)
        {
            var game = await _gameServices.GetGameById(id);
            return View(game);
        }
        public async Task<IActionResult> EditGame(int id)
        {
            var game = await _gameServices.GetGameById(id);
            var editGameVM = new EditVM
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                CategoryId = (int)game.CategoryId,
                CurrentCover = game.CoverName,
                Categories= _categoryServices.CategorySelectList(),
                SelectedDevices = game.Devices.Select(d=>d.DeviceId).ToList(),
                Devices= _deviceService.DeviceSelectList(),
            };
            return View(nameof(EditGame), editGameVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGame(EditVM game)
        {

            if (!ModelState.IsValid)
            {
                game.Devices = _deviceService.DeviceSelectList();
                game.Categories = _categoryServices.CategorySelectList();
                return View(game);
            }



            await _gameServices.UpdateGame(game);
            return Redirect("/Admin/Home/Games");

        }
        public async Task<IActionResult> DeleteGame(int id)
        {
            if (id > 0)
            {
                await _gameServices.DeleteGame(id);
                return Redirect("/Admin/Home/Games");
            }
            return View(nameof(DeleteGame));
        }

    }
}
