using System.Diagnostics;

namespace typeTest;

class Game
{
  //need to do setters for initials and game clock to use no args constructor
  public string Initials { get; set; } //3
  public int Score { get; set; }
  public TimeSpan GameClock { get; set; } //gameClock.Elapsed.Seconds.ToString();
  public bool IsActive { get; set; } //game started/ended
  public DateTime GameDate { get; set; } //if not today, set to DateOnly
  public List<string> Quotes { get; set; }

  public Game() { }

  public Game(
    string Initials,
    int Score,
    TimeSpan GameClock,
    bool IsActive,
    DateTime GameDate,
    List<string> Quotes
  )
  {
    this.Initials = Initials;
    this.Score = Score;
    this.GameClock = GameClock;
    this.IsActive = IsActive;
    this.GameDate = GameDate;
    this.Quotes = Quotes;
  }

}