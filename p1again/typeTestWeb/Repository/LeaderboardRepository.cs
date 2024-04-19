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
}
