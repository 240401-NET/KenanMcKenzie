using typeTestWeb.Models;
namespace typeTestWeb.Interface;

public interface ILeaderboardRepository
{
  public List<Game> GetLeaderboard();
}
