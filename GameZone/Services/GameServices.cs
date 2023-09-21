using GameZone.Controllers;
using GameZone.Data;
using GameZone.Models;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
    public class GameServices : IGameServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public GameServices(ApplicationDbContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task AddGame(GameVM game)
        {
            try
            {
                if (game == null)
                    throw new ArgumentNullException("game");
                var imgName = await saveImage(game.Cover);
                var Game = new Game
                {
                    Name = game.Name,
                    Description = game.Description,
                    CoverName = imgName,
                    CategoryId = game.CategoryId,
                    Devices = game.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList(),
                };
                await _context.TbGames.AddAsync(Game);
                _context.SaveChanges();
            }
            catch { }
        }

        public async Task DeleteGame(int id)
        {
            try
            {
                var game = await GetGameById(id);
                if (game == null)
                    throw new ArgumentException("game");
                _context.TbGames.Remove(game);
                _context.SaveChanges();
            }
            catch { }
        }

        public async Task<Game> GetGameById(int id)
        {
            try
            {
                var game = await _context.TbGames.FindAsync(id);
                if (game == null)
                    throw new ArgumentNullException("game");
                return game;
            }
            catch { throw new InvalidOperationException(); }
        }

        public async Task<List<Game>> GetGames()
        {
            try
            {
                var games = await _context.TbGames.ToListAsync();
                return games;
            }
            catch { throw new ArgumentNullException("games"); }
        }

        public async Task UpdateGame(EditVM game)
        {
            try
            {
                if (game is not null)
                {
                    var Game = _context.TbGames.Include(d => d.Devices).SingleOrDefault(g => g.Id == game.Id);
                    var imgName = "";
                    var oldImgName = Game.CoverName;
                    if (game.Cover is not null)
                    {
                         imgName= await saveImage(game.Cover!);
                        var oldImage = Path.Combine(_webHostEnvironment.WebRootPath, $"Uploads/Images/{oldImgName}");
                        File.Delete(oldImage);
                    }
                    else
                    {
                        imgName = Game.CoverName;
                    }

                    Game.Id = game.Id;
                    Game.Name = game.Name;
                    Game.Description = game.Description;
                    Game.CategoryId = game.CategoryId;
                    Game.Devices = game.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList();
                    Game.CoverName = imgName;

                    await _context.SaveChangesAsync();
                }
            }
            catch { }
        }
        private async Task<string> saveImage(IFormFile image)
        {
            var imgName = $"{Guid.NewGuid()}.{Path.GetExtension(image.FileName)}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), _webHostEnvironment.WebRootPath, $"Uploads/Images/{imgName}");
            using var stream = System.IO.File.Create(path);
            await image.CopyToAsync(stream);
            return imgName;
        }
    }
}
