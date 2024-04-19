using typeTestWeb.Models;
namespace typeTestWeb.Interface;

public interface IGameRepository
{
  Task<IEnumerable<Game>> GetAllGamesAsync();
  Task<Game?> GetGameByIdAsync(int gameId);
  Task AddGameAsync(Game game);
  Task UpdateGameAsync(Game game);
  Task DeleteGameAsync(int gameId);
}
