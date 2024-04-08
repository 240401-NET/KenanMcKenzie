using System.Text.Json;

namespace typeTest;

class Data
{
  public static string leaderboardFile = "leaderboard.json";
  public static void SaveGame(List<Game> gamesList)
  {
    JsonSerializerOptions options = new()
    {
      WriteIndented = true
    };
    try
    {
      string jsonGames = JsonSerializer.Serialize(gamesList);
      File.WriteAllText(leaderboardFile, jsonGames);
    }
    catch (Exception ex)
    {
      Console.WriteLine("Error saving games: " + ex.Message);
      throw;
    }
  }

  public static List<Game> LoadGames()
  {
    try
    {
      string jsonGames = File.ReadAllText(leaderboardFile);

      return JsonSerializer.Deserialize<List<Game>>(jsonGames) ?? new List<Game>();
    }
    catch (Exception ex)
    {
      Console.WriteLine("Error loading games: " + ex.Message);
      throw;
    }
  }
}