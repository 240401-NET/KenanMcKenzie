using System.Diagnostics;
using System.Text.RegularExpressions;

namespace typeTest;

public class Logic
{
  private static int numCorrect;

  private static int numIncorrect;
  private static List<Game> completedGames = new();

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
    else if (keyPressed == ConsoleKey.L)
    {
      Leaderboard.DisplayLeaderboard(completedGames);
      if (keyPressed == ConsoleKey.Enter)
      {
        Console.Clear();
        Menu.PrintHeader();
      }
    }
  }

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

  public static string[] GetQuotes()
  {
    try
    {
      string filePath = "quotes.txt";
      string quoteTxt = File.ReadAllText(filePath);
      //dividing body into sentences -> getting rid of spaces to start sentence -> array
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
    //displaying one sentence at a time
    for (int i = 0; i < quotes.Length; i++)
    {
      string quotesStr = quotes[i];
      Console.WriteLine(quotesStr);
      //checking each char in sentence
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
  public static void IncorrectKey(char kp)
  {
    numIncorrect++;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(kp);
  }

  public static Game EndGame(double minutes)
  {
    //setting list to previous data before adding to it
    completedGames = Data.LoadGames();

    double accuracy = CalculateAccuracy(numCorrect, numIncorrect);
    double wordsPerMinute = CalculateWPM(minutes);
    double adjusted = CalculateAWPM(minutes);
    Console.WriteLine("** Accuracy: " + accuracy * 100 + "% **");
    Console.WriteLine("** Words Per Minute: " + wordsPerMinute + " **");
    Console.WriteLine("** Adjusted Words Per Minute: " + adjusted + " **");

    string userInitials = CollectInitials();
    var today = DateOnly.FromDateTime(DateTime.Now);
    //setting game properties -> adding to list -> returning to main menu
    Game newGame = new()
    {
      Initials = userInitials,
      Accuracy = accuracy * 100,
      WPM = wordsPerMinute,
      AWPM = adjusted,
      Date = today
    };

    completedGames.Add(newGame);
    Data.SaveGame(completedGames);
    Thread.Sleep(3000);
    Console.Clear();
    Menu.PrintHeader();
    return newGame;
  }

  public static string CollectInitials()
  {
    Console.WriteLine("Enter your initials: ");
    string userInput = Console.ReadLine();
    if (!IsValid(userInput))
    {
      return CollectInitials();
    }
    return userInput;
  }
  public static bool IsValid(string input)
  {

    if (!input.All(char.IsLetter))
    {
      Console.WriteLine("Must only contain letters");
      return false;
    }
    if (input.Length != 3)
    {
      Console.WriteLine("Must be 3 letters");
      return false;
    }
    return true;
  }

  /***          End of Game Calculations          ***/
  public static int GetTotal(int correct, int incorrect)
  {
    return correct + incorrect;
  }

  //Gets accuracy as 2-digit double
  public static double CalculateAccuracy(int correct, int incorrect)
  {
    int total = GetTotal(correct, incorrect);
    double ratio = (double)correct / total;
    return Math.Round(ratio, 2);
  }
  //words per minute = total keys pressed/word(any 5 characters)
  public static double CalculateWPM(double minutes)
  {
    int totalWords = GetTotal(numCorrect, numIncorrect);
    double WPM = Math.Round(totalWords / 5 / minutes);
    return WPM;
  }
  //adjusted words per minute = wpm x accuracy -> to nearest whole number
  public static double CalculateAWPM(double minutes)
  {
    double adjustedWPM = Math.Round(CalculateAccuracy(numCorrect, numIncorrect) * CalculateWPM(minutes));
    return adjustedWPM;
  }
}