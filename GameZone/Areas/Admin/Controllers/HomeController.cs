using GameZone.Models;
using GameZone.Services;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IGameServices _gameServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IDeviceService _deviceService;

        public HomeController(IGameServices gameServices, ICategoryServices categoryServices, IDeviceService deviceService)
        {
            _gameServices = gameServices;
            _categoryServices = categoryServices;
            _deviceService = deviceService;
        }
    
        public async Task<IActionResult> Games()
        {
            var games = await _gameServices.GetGames();
            return View(games);
        }
        public async Task<IActionResult> Categories()
        {
            ViewBag.categories = await _categoryServices.GetCategories();
            return View(new Category());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(Category cat)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.categories = await _categoryServices.GetCategories();
                return View(cat);
            }
            if (cat.Id > 0)
            {
                await _categoryServices.EditCategory(cat);
            }
            else
            {
                await _categoryServices.AddCategory(cat);
            }
            return RedirectToAction(nameof(Categories));
        }
        public async Task<IActionResult> EditCategory(int id)
        {
            var cat = await _categoryServices.GetCategoryById(id);
            ViewBag.categories = await _categoryServices.GetCategories();
            return View(nameof(Categories), cat);
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryServices.DeleteCategory(id);
            return RedirectToAction(nameof(Categories));
        } 
        public async Task<IActionResult> Devices()
        {
            ViewBag.devices = await _deviceService.GetDevices();
            return View(new Device());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDevice(Device device)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.devices = await _deviceService.GetDevices();
                return View(device);
            }
            if (device.Id > 0)
            {
                await _deviceService.EditDevice(device);
            }
            else
            {
                await _deviceService.AddDevice(device);
            }
            return RedirectToAction(nameof(Devices));
        }
        public async Task<IActionResult> EditDevice(int id)
        {
            var cat = await _deviceService.GetDeviceById(id);
            ViewBag.devices = await _deviceService.GetDevices();
            return View(nameof(Devices), cat);
        }
        public async Task<IActionResult> DeleteDevice(int id)
        {
            await _deviceService.DeleteDevice(id);
            return RedirectToAction(nameof(Devices));
        }
        
    }
}
