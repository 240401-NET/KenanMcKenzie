using System.Text.Json;

namespace typeTest;

class Logic
{
  //set game state 
  //make separate class for reading and splitting json or do it here

  //Methods
  //display instructions - start, quit, leaderboard, pause?
  public static void PrintInstructions()
  {
    Console.WriteLine("Type the text on the screen as quickly as you can. \n"
    + "Bonus points awarded for completing in under 2 minutes.");
  }

  public static void PrintCommands()
  {
    Console.WriteLine("Esc = quit, Enter = start");
  }
  //startGame -> new Game(), myStopWatch.Start(), Api.getQuotes(), score to 0, initials to empty string, displayText(), isActive to true
  public static void StartGame()
  {
    Game newGame = new();
    newGame.GameDate = DateTime.Now;
    newGame.IsActive = true;
    newGame.Score = 0;
    newGame.Quotes = ListQuotes();
    foreach (string quote in newGame.Quotes)
    {
      Console.WriteLine(quote + "\n");
    }
    Console.WriteLine(newGame.Quotes.Capacity);
  }

  public static List<string> ListQuotes()
  {
    try
    {
      string filePath = "quotes.json";
      string jsonQuotes = File.ReadAllText(filePath);

      return JsonSerializer.Deserialize<List<string>>(jsonQuotes) ?? new List<string>();
    }
    catch (Exception e)
    {
      Console.WriteLine("Error: " + e.Message);
      throw;
    }
  }

  //displayText -> deserialize from saved json, split into senetences, display 1 unused sentence (maybe split into more methods)
  //endOfSentence -> when input == split sentence.length..reset displayText and what the user has typed so far. (maybe don't display user text like typemonkey)
  //checkInput -> if inputPosition == sentence.charAt(inputPosition + 1?) rightKey() else wrongKey()
  //rightKey -> score += 1, char to green
  //wrongKey -> score -= 1, char to red
  //endGame -> myStopWatch.Stop() -> display time elapsed myStopWatch.Elapsed + add points for under 3 minutes, prompts for initials, shows spot in leaderboard, Game.isActive false
  //maybe create Map for Game attributes
}