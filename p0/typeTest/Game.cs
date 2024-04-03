using System.Diagnostics;

namespace typeTest;

class Game
{
  private string Initials { get; set; } //3
  private int Score { get; set; }
  private Stopwatch GameClock { get; set; } //gameClock.Elapsed.Seconds.ToString();
  private bool IsActive { get; set; } //game started/ended
  private DateTime GameDate { get; set; } //if not today, set to DateOnly

  public Game() { }

  public Game(
    string Initials,
    int Score,
    Stopwatch GameClock,
    bool isActive
  )
  {
    this.Initials = Initials;
    this.Score = Score;
    this.GameClock = GameClock;
    this.IsActive = isActive;
  }

}