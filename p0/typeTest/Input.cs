using System.Diagnostics;

namespace typeTest;

class Input
{
  //takes in keys as user is typing
  //fields: position, value
  //quit game-> hit esc
  public static void Type()
  {
    do
    {
      var timer = new Stopwatch(); //move to 
      timer.Start();
      ConsoleKeyInfo keyInfo = Console.ReadKey(true);
      Console.WriteLine($"Key: {keyInfo.KeyChar}");
      timer.Stop();

      if (keyInfo.Key == ConsoleKey.Escape)
      {
        TimeSpan timeTaken = timer.Elapsed;
        string timeString = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
        Console.WriteLine(timeString);
        break;
      }
    } while (true);

  }

}