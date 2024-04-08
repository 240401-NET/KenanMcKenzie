namespace typeTest;

class Leaderboard
{
  //save Game.Score to new json file 
  //create table, initials | score | completedIn(time) | date display top 50 
  public static void DisplayLeaderboard(List<Game> gamesList)
  {
    string leaderboardHeader = @"
    __                   __          __                         __
   / /   ___  ____ _____/ /__  _____/ /_  ____  ____ __________/ /
  / /   / _ \/ __ `/ __  / _ \/ ___/ __ \/ __ \/ __ `/ ___/ __  / 
 / /___/  __/ /_/ / /_/ /  __/ /  / /_/ / /_/ / /_/ / /  / /_/ /  
/_____/\___/\__,_/\__,_/\___/_/  /_.___/\____/\__,_/_/   \__,_/   
                                                                  
";
    Console.Clear();
    Console.WriteLine(leaderboardHeader + "\n\n");
    Console.WriteLine("#" + "\t Player \tAccuracy \tW.P.M. \tA.W.P.M");
    gamesList = Data.LoadGames().OrderByDescending(awpm => awpm.AWPM).ToList();
    for (int i = 0; i < gamesList.Count; i++)
    {
      Console.WriteLine(i + "\t " + gamesList[i].Initials + "\t " + gamesList[i].Accuracy + "\t " + gamesList[i].WPM + "\t " + gamesList[i].AWPM);
    }
  }

}