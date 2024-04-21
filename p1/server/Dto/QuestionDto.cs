using server.Dto;

namespace server.Model;

public class QuestionDTO
{
  public string QuestionText { get; set; }
  public string Example { get; set; }
  public List<QuestionOptionsDto> Options { get; set; }
}