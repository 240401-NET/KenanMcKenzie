using typeTestWeb.Models;
namespace typeTestWeb.Interface;

public interface ILeaderboardRepository
{
  public List<Game> GetLeaderboard();
  List<Game> GetLeaderboardByUserId(int userId);
  List<Game> GetLeaderboardByDate(DateTime date);
  Game GetGameById(int gameId);


}
