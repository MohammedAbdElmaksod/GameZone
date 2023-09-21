using GameZone.Models;
using GameZone.ViewModels;

namespace GameZone.Services
{
    public interface IGameServices
    {
        Task AddGame(GameVM game);
        Task<List<Game>> GetGames();
        Task<Game> GetGameById(int id);
        Task DeleteGame(int id);
        Task UpdateGame(EditVM  game);
    }
}
