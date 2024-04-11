using System;
using System.Collections.Generic;

namespace server;

public partial class QuestionOption
{
    public int OptionId { get; set; }

    public string OptionText { get; set; } = null!;

    public bool IsAnswer { get; set; }

    public int BelongsToQuestion { get; set; }

    public virtual Question BelongsToQuestionNavigation { get; set; } = null!;
}
