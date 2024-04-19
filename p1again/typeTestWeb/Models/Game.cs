using System;
using System.Collections.Generic;

namespace typeTestWeb.Models;

public partial class Game
{
    public int GameId { get; set; }

    public int? UserId { get; set; }

    public int? Score { get; set; }

    public DateTime? GameDate { get; set; }

    public double? Wpm { get; set; }

    public double? Awpm { get; set; }

    public double? Accuracy { get; set; }

    public string? GameText { get; set; }

    public decimal? TimeTaken { get; set; }

    public virtual AppUser? User { get; set; }
}
