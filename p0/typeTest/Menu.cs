namespace typeTest;

class Menu
{
  public static void PrintHeader()
  {
    string title = @"
  ____    _    ____ ___  _   _   _______   ______  _____ 
 | __ )  / \  / ___/ _ \| \ | | |_   _\ \ / /  _ \| ____|
 |  _ \ / _ \| |  | | | |  \| |   | |  \ V /| |_) |  _|  
 | |_) / ___ \ |__| |_| | |\  |   | |   | | |  __/| |___ 
 |____/_/   \_\____\___/|_| \_|   |_|   |_| |_|   |_____|
                                                         
";
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(title);
  }




  public static void PrintInstructions()
  {
    Console.WriteLine("Type the text on the screen as quickly as you can. \n"
    + "Bonus points awarded for completing in under 2 minutes.");
  }

  //TODO: Log and act on input
  public static void PrintCommands()
  {
    Console.WriteLine("Esc = quit, Enter = start");
  }
}