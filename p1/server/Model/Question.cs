using System;
using System.Collections.Generic;

namespace server.Model;

public partial class Question
{
    public int QuestionId { get; set; }

    public string QuestionText { get; set; } = null!;

    public int BelongsTo { get; set; }

    public string? Example { get; set; }

    public virtual ICollection<QuestionOption> QuestionOptions { get; set; } = new List<QuestionOption>();
}
