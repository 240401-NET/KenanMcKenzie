namespace typeTest;

class Menu
{
  public static void PrintHeader()
  {
    string title = @"
  _______   ________   ______   ______   ___   __        _________  __  __   ______   ______      
/_______/\ /_______/\ /_____/\ /_____/\ /__/\ /__/\     /________/\/_/\/_/\ /_____/\ /_____/\     
\::: _  \ \\::: _  \ \\:::__\/ \:::_ \ \\::\_\\  \ \    \__.::.__\/\ \ \ \ \\:::_ \ \\::::_\/_    
 \::(_)  \/_\::(_)  \ \\:\ \  __\:\ \ \ \\:. `-\  \ \      \::\ \   \:\_\ \ \\:(_) \ \\:\/___/\   
  \::  _  \ \\:: __  \ \\:\ \/_/\\:\ \ \ \\:. _    \ \      \::\ \   \::::_\/ \: ___\/ \::___\/_  
   \::(_)  \ \\:.\ \  \ \\:\_\ \ \\:\_\ \ \\. \`-\  \ \      \::\ \    \::\ \  \ \ \    \:\____/\ 
    \_______\/ \__\/\__\/ \_____\/ \_____\/ \__\/ \__\/       \__\/     \__\/   \_\/     \_____\/ 
                                                                                                  
";
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(title);
    Console.WriteLine("Esc = Quit, Enter = Start, L = Leaderboard\n\n");
    Console.ResetColor();
  }




  public static void PrintInstructions()
  {
    Console.WriteLine("Type the text on the screen as quickly and accurately as you can! \nPress delete to return home");
    Thread.Sleep(2500);
  }

  //TODO: Log and act on input


  public static void PrintCountDown()
  {
    string[] countdown = { @"
██████  
     ██ 
 █████  
     ██ 
██████  
        
        
", @"
██████  
     ██ 
 █████  
██      
███████ 
        
        
", @"
 ██ 
███ 
 ██ 
 ██ 
 ██ 
    
    
", @"
 ██████   ██████  ██ 
██       ██    ██ ██ 
██   ███ ██    ██ ██ 
██    ██ ██    ██    
 ██████   ██████  ██ 
                     
                     
" };
    for (int i = 0; i < countdown.Length; i++)
    {
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine(countdown[i]);
      Thread.Sleep(1000);
      Console.Clear();
    }
    Console.ResetColor();
  }


}