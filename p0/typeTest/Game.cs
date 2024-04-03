using System.Diagnostics;

namespace typeTest;

class Game
{
  //need to do setters for initials and game clock to use no args constructor
  private string Initials { get; set; } //3
  public int Score { get; set; }
  private Stopwatch GameClock { get; set; } //gameClock.Elapsed.Seconds.ToString();
  private bool IsActive { get; set; } //game started/ended
  private DateTime GameDate { get; set; } //if not today, set to DateOnly

  public Game() { }

  public Game(
    string Initials,
    int Score,
    Stopwatch GameClock,
    bool IsActive,
    DateTime GameDate
  )
  {
    this.Initials = Initials;
    this.Score = Score;
    this.GameClock = GameClock;
    this.IsActive = IsActive;
    this.GameDate = GameDate;
  }

}