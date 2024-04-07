
using System.Diagnostics;



namespace typeTest;

class Logic
{
  private static int numCorrect;

  private static int numIncorrect;


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
  public static int GetTotal(int correct, int incorrect)
  {
    return correct + incorrect;
  }
  public static double CalculateAccuracy()
  {
    int total = GetTotal(numCorrect, numIncorrect);
    double ratio = (double)numCorrect / total;
    return Math.Round(ratio, 2);
  }
  public static double CalculateWPM(double minutes)
  {
    int totalWords = GetTotal(numCorrect, numIncorrect);
    double WPM = Math.Round(totalWords / 5 / minutes);
    return WPM;
  }
  public static double CalculateAWPM(double minutes)
  {
    double adjustedWPM = Math.Round(CalculateAccuracy() * CalculateWPM(minutes));
    return adjustedWPM;
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

  public static void DisplaySentence(string[] quotes)
  {


    for (int i = 0; i < quotes.Length; i++)
    {
      string quotesStr = quotes[i];

      Console.WriteLine(quotesStr);

      for (int j = 0; j < quotesStr.Length; j++)
      {
        ConsoleKeyInfo keyPressed = Console.ReadKey(true);
        char keyInfo = keyPressed.KeyChar;
        ConsoleKey key = keyPressed.Key;

        if (keyInfo.Equals(quotesStr[j]))
        {
          CorrectKey(keyInfo);
        }
        else if (key.Equals(ConsoleKey.Delete))
        {
          Console.WriteLine("Goodbye!");
          Thread.Sleep(1000);

          Console.Clear();
          Menu.PrintHeader();
          break;
        }
        else
        {
          IncorrectKey(keyInfo);
        }

        Console.ResetColor();
      }
      Console.Clear();
    }
  }


  public static void CorrectKey(char kp)
  {
    numCorrect++;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(kp);
  }
  //wrongKey -> score -= 1, char to red
  public static void IncorrectKey(char kp)
  {
    numIncorrect++;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(kp);
  }
  //revertScore -> if KeyChar is backspace, revert score
  //endGame -> myStopWatch.Stop() -> display time elapsed myStopWatch.Elapsed + add points for under 3 minutes, prompts for initials, shows spot in leaderboard, Game.isActive false
  public static void EndGame(double minutes)
  {
    Console.WriteLine("** Accuracy: " + CalculateAccuracy() * 100 + "%");
    Console.WriteLine("** Words Per Minute: " + CalculateWPM(minutes));
    Console.WriteLine("** Adjusted Words Per Minute: " + CalculateAWPM(minutes));

    Thread.Sleep(3000);
    Console.Clear();
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
    Menu.PrintHeader();
  }


  //List<Input> elements = [{score was ++ or --, cursor position, keyPressed }, {}]
  //


  //parent function to logic methods
  public static void Run()
  {
    var timer = new Stopwatch();
    timer.Start();
    string[] quotes = GetQuotes();
    DisplaySentence(quotes);
    timer.Stop();
    TimeSpan timeTaken = timer.Elapsed;
    double minutes = Math.Round(timeTaken.TotalMinutes, 2);
    EndGame(minutes);
  }
  //maybe create Map for Game attributes
}