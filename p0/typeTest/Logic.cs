using System.Diagnostics;
using System.Text.RegularExpressions;

namespace typeTest;

public class Logic
{
  private static int numCorrect;

  private static int numIncorrect;
  private static List<Game> completedGames = new();

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
  public static void IncorrectKey(char kp)
  {
    numIncorrect++;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(kp);
  }
  public static bool IsValid(string input)
  {
    string pattern = @"/^[A-Za-z]+$/";
    Regex regex = new Regex(pattern);
    if (regex.IsMatch(input))
    {
      Console.WriteLine("regex prob");
      return false;
    }
    if (input.Length != 3)
    {
      Console.WriteLine("Must be 3 letters");
      return false;
    }
    return true;
  }

  public static Game EndGame(double minutes)
  {
    double accuracy = CalculateAccuracy();
    double wordsPerMinute = CalculateWPM(minutes);
    double adjusted = CalculateAWPM(minutes);
    Console.WriteLine("** Accuracy: " + accuracy * 100 + "% **");
    Console.WriteLine("** Words Per Minute: " + wordsPerMinute + " **");
    Console.WriteLine("** Adjusted Words Per Minute: " + adjusted + " **");
    string userInitials = CollectInitials();
    Game newGame = new()
    {
      Initials = userInitials,
      Accuracy = accuracy * 100,
      WPM = wordsPerMinute,
      AWPM = adjusted
    };
    completedGames.Add(newGame);
    Thread.Sleep(3000);
    Console.Clear();
    return newGame;
  }

  public static string CollectInitials()
  {
    Console.WriteLine("Enter your initials: ");
    string userInput = Console.ReadLine();
    if (!IsValid(userInput))
    {
      Console.WriteLine("Initials must only contain 3 letters.\n Please try again");
      return CollectInitials();
    }
    return userInput;
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
}