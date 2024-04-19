using typeTestWeb.Interface;
using typeTestWeb.Models;
namespace typeTestWeb.Repository;

public class LeaderboardRepository : ILeaderboardRepository
{
  private readonly FreeDBContext _context;
  public LeaderboardRepository(FreeDBContext context)
  {
    _context = context;
  }
  public List<Game> GetLeaderboard()
  {
    return _context.Games.OrderByDescending(g => g.Wpm).ToList();
  }

  public List<Game> GetLeaderboardByUserId(int userId)
  {
    return _context.Games.Where(g => g.UserId == userId).OrderByDescending(g => g.Wpm).ToList();
  }

  public List<Game> GetLeaderboardByDate(DateTime date)
  {
    return _context.Games.Where(g => g.GameDate == date).OrderByDescending(g => g.Wpm).ToList();
  }

  public Game GetGameById(int gameId)
  {
    return _context.Games.FirstOrDefault(g => g.GameId == gameId);
  }
}
