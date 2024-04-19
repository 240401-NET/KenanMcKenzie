using System;
using System.Collections.Generic;

namespace typeTestWeb.Models;

public partial class AppUser
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();

    public virtual ICollection<Leaderboard> Leaderboards { get; set; } = new List<Leaderboard>();
}
