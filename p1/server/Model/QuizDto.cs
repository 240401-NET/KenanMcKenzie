namespace server.Model;

public class QuizDTO
{
  public string Title { get; set; }

  public string Description { get; set; }

  public string CreatedBy { get; set; }

  public List<string> Tags { get; set; }

  public List<Question> Questions { get; set; }
}