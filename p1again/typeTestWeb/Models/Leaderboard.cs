using System;
using System.Collections.Generic;

namespace typeTestWeb.Models;

public partial class Leaderboard
{
    public int LeaderboardId { get; set; }

    public int? UserId { get; set; }

    public int? HighScore { get; set; }

    public virtual AppUser? User { get; set; }
}
