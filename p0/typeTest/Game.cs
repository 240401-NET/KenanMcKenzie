namespace typeTest;

public class Game
{
  public string Initials { get; set; }
  public double WPM { get; set; }
  public double AWPM { get; set; }
  public double Accuracy { get; set; }
  public DateOnly Date { get; set; }

  public Game() { }

  public Game(
    string Initials,
    double WPM,
    double AWPM,
    double Accuracy,
    DateOnly Date
  )
  {
    this.Initials = Initials;
    this.WPM = WPM;
    this.AWPM = AWPM;
    this.Accuracy = Accuracy;
    this.Date = Date;
  }


}