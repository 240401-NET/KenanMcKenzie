namespace typeTest;

using System.Data;
using ConsoleTables;
class Leaderboard
{
  //save Game.Score to new json file 
  //create table, initials | score | completedIn(time) | date display top 50 
  public static void DisplayLeaderboard(List<Game> gamesList)
  {
    var table = new ConsoleTable("#", "Player", "Accuracy", "WPM", "AdjWPM", "Date");
    string leaderboardHeader = @"
    __                   __          __                         __
   / /   ___  ____ _____/ /__  _____/ /_  ____  ____ __________/ /
  / /   / _ \/ __ `/ __  / _ \/ ___/ __ \/ __ \/ __ `/ ___/ __  / 
 / /___/  __/ /_/ / /_/ /  __/ /  / /_/ / /_/ / /_/ / /  / /_/ /  
/_____/\___/\__,_/\__,_/\___/_/  /_.___/\____/\__,_/_/   \__,_/   
                                                                  
";
    Console.Clear();
    Console.WriteLine(leaderboardHeader + "\n\n");


    gamesList = Data.LoadGames().OrderByDescending(awpm => awpm.AWPM).ToList();
    for (int i = 0; i < gamesList.Count; i++)
    {
      table.AddRow(i + 1, gamesList[i].Initials, gamesList[i].Accuracy + "%", gamesList[i].WPM, gamesList[i].AWPM, gamesList[i].Date);
    }
    table.Write();

    Console.WriteLine("Hit any key to return home.");
    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
    Console.Clear();
    Menu.PrintHeader();
  }

}