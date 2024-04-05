using System.Text;
using System;
using System.Diagnostics;



namespace typeTest;

class Logic
{
  private static int numCorrect;
  private static int total;

  //set game state 
  //make separate class for reading and splitting json or do it here

  //Methods

  //startGame -> new Game(), myStopWatch.Start(), Api.getQuotes(), score to 0, initials to empty string, displayText(), isActive to true
  // public static void StartGame()
  // {

  //   Game newGame = new();
  //   newGame.GameDate = DateTime.Now;
  //   newGame.IsActive = true;
  //   newGame.Score = 0;
  //   newGame.Quotes = ListQuotes(); //maybe remove from Game, already getting new quotes each game
  //   // foreach (string quote in newGame.Quotes)
  //   // {
  //   //   Console.WriteLine(quote + "\n");
  //   // }
  //   Console.WriteLine(newGame.Quotes.Capacity);
  // }

  //calculateAccuracy -> #correct/total; make variable to keep count of right and quoteTxt.Length == Total;
  public static string CalculateAccuracy(int total, int numCorrect)
  {
    double ratio = (double)total / numCorrect;
    if (ratio != 1)
    {
      string ratioString = string.Format("{0:0.00}", ratio);

      string formatted = ratioString.Substring(2, 2) + "%";
      return formatted;
    }
    else return "100%";
  }

  public static string[] GetQuotes()
  {
    try
    {
      string filePath = "quotes.txt";
      string quoteTxt = File.ReadAllText(filePath);
      string[] quotes = quoteTxt.Split(".").Select(sentence => sentence.Trim()).ToArray();

      return quotes;
    }
    catch (Exception e)
    {
      Console.WriteLine("Error: " + e.Message);
      throw;
    }
  }

  //displayText -> deserialize from saved json, split into senetences, display 1 unused sentence at a time(maybe split into more methods)
  public static void DisplaySentence(string[] quotes, ref int numCorrect, ref int total)
  {
    //log the key pressed

    int score = 0;
    //compare key pressed with char in charArr
    for (int i = 0; i < quotes.Length; i++)
    {
      string quotesStr = quotes[i];
      total += quotes[i].Length;
      Console.WriteLine("Score: " + score);
      Console.WriteLine(quotesStr);

      for (int j = 0; j < quotesStr.Length; j++)
      {
        ConsoleKeyInfo keyPressed = Console.ReadKey(true);
        char keyInfo = keyPressed.KeyChar;

        if (keyInfo.Equals(quotesStr[j]))
        {
          numCorrect++;
          score++;
          Console.ForegroundColor = ConsoleColor.Green;
          Console.Write(keyInfo);
        }
        else
        {
          score--;
          Console.ForegroundColor = ConsoleColor.Red;
          Console.Write(keyInfo);
        };
        Console.ResetColor();
      }
      Console.Clear();
    }
    Console.WriteLine("SCORE: " + score);
  }


  public static void CorrectKey(int score)
  {
    Console.ForegroundColor = ConsoleColor.Green;
    score++;
  }
  //wrongKey -> score -= 1, char to red
  public static void IncorrectKey(int score)
  {
    Console.ForegroundColor = ConsoleColor.Red;
    score--;
  }
  //revertScore -> if KeyChar is backspace, revert score
  //endGame -> myStopWatch.Stop() -> display time elapsed myStopWatch.Elapsed + add points for under 3 minutes, prompts for initials, shows spot in leaderboard, Game.isActive false
  public static void EndGame()
  {

  }

  public static void HandleMenuCmdInput()
  {
    ConsoleKeyInfo key = Console.ReadKey(true);
    ConsoleKey keyPressed = key.Key;
    if (keyPressed == ConsoleKey.Escape)
    {
      Environment.Exit(0);
    }
    else if (keyPressed == ConsoleKey.Enter)
    {
      Menu.PrintInstructions();
      Menu.PrintCountDown();
      Run();
    }
  }

  //parent function to logic methods
  public static void Run()
  {
    var timer = new Stopwatch(); //move to 
    timer.Start();
    string[] quotes = GetQuotes();
    DisplaySentence(quotes, ref numCorrect, ref total);
    timer.Stop();
    TimeSpan timeTaken = timer.Elapsed;
    Console.WriteLine(timeTaken.ToString(@"m\:ss\.fff"));
    Console.WriteLine("Total words: " + total + "\nTotalCorrect: " + numCorrect);


    Console.WriteLine("Accuracy: " + CalculateAccuracy(numCorrect, total));

  }
  //maybe create Map for Game attributes
}