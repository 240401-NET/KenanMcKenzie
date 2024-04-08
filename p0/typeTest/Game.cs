namespace typeTest;

public class Game
{
  //need to do setters for initials and game clock to use no args constructor
  public string Initials { get; set; }
  public double WPM { get; set; }
  public double AWPM { get; set; }
  public double Accuracy { get; set; }
  public bool IsActive { get; set; }
  public DateOnly Date { get; set; }

  public Game() { }

  public Game(
    string Initials,
    double WPM,
    double AWPM,
    double Accuracy,
    bool IsActive,
    DateOnly Date
  )
  {
    this.Initials = Initials;
    this.WPM = WPM;
    this.AWPM = AWPM;
    this.Accuracy = Accuracy;
    this.IsActive = IsActive;
    this.Date = Date;
  }


}