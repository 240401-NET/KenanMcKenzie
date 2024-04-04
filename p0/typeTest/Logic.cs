using System.Text.Json;
using System;


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

  public static string[] GetQuotes()
  {
    try
    {
      string filePath = "quotes.txt";
      string quoteTxt = File.ReadAllText(filePath);

      // string[] quotes = JsonSerializer.Deserialize<string[]>(jsonQuotes) ?? new string[0];
      string[] quotes = quoteTxt.Split(".").Select(sentence => sentence.Trim()).ToArray();

      return quotes; //foreach trim double whitespaces to 1
    }
    catch (Exception e)
    {
      Console.WriteLine("Error: " + e.Message);
      throw;
    }
  }

  //displayText -> deserialize from saved json, split into senetences, display 1 unused sentence at a time(maybe split into more methods)
  // public static void Split(string[] quotes)
  // {
  //   quotes.Join(",")
  // }

  //endOfSentence -> when input == split sentence.length..reset displayText and what the user has typed so far. (maybe don't display user text like typemonkey)

  //checkInput -> if inputPosition == sentence.charAt(inputPosition + 1?) rightKey() else wrongKey()
  public static void ReadNextChar() //change return to bool and handle score elsewhere. Either call Input.Type here or get rid of it
  {
    string paragraph = "Ut ham chuck ut exercitation venison shoulder corned beef.  Commodo pork kielbasa, short loin jerky ribeye rump chicken irure consectetur velit ut hamburger.  Do doner nisi dolor short loin shoulder cow eu chuck exercitation kevin.  Short loin pork belly chuck kielbasa spare ribs qui buffalo pariatur in t-bone.  Tail prosciutto turducken, elit dolore ball tip pancetta chicken bacon filet mignon short ribs veniam pork.  Picanha kevin pork jowl filet mignon shank id hamburger leberkas mollit dolore.";
    Console.WriteLine(paragraph);
    int score = 0;
    int selectedIndex;
    do
    {
      char[] result = paragraph.ToCharArray();
      ConsoleKeyInfo key = Console.ReadKey(true);
      char keyChar = key.KeyChar;
      //increment key presses and set as index of result
      if (keyChar.Equals(result[0]))
      {
        //make above line a var and have different method to change color of that foreground
        Console.ForegroundColor = ConsoleColor.Green;
        score++;
        Console.WriteLine("Score: " + score);
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Red;

        score--;
        Console.WriteLine("Score: " + score);
        Console.ForegroundColor = ConsoleColor.White;
      }
    } while (true);
  }
  //rightKey -> score += 1, char to green
  public void CorrectKey()
  {

  }
  //wrongKey -> score -= 1, char to red
  public void IncorrectKey()
  {

  }
  //revertScore -> if KeyChar is backspace, revert score
  //endGame -> myStopWatch.Stop() -> display time elapsed myStopWatch.Elapsed + add points for under 3 minutes, prompts for initials, shows spot in leaderboard, Game.isActive false
  public static void EndGame()
  {

  }
  //maybe create Map for Game attributes
}