using server.Interface;
using server.Model;

namespace server.Service;

public class QuizService : IQuizService
{
  private readonly IQuizRepository _quizRepository;
  private readonly IUserRepository _userRepository;
  public QuizService(IQuizRepository quizRepository, IUserRepository userRepository)
  {
    _quizRepository = quizRepository;
    _userRepository = userRepository;
  }

  public async Task<int> CreateQuiz(QuizDTO quizDTO)
  {
    if (quizDTO.Questions.Count == 0)
    {
      throw new FormatException("Quiz must have at least one question");
    }
    if (quizDTO.Title.Length == 0 || quizDTO.Title == null)
    {
      throw new FormatException("Quiz must have a title");
    }
    if (quizDTO.Tags.Count > 3)
    {
      throw new FormatException("Maximum number of tags exceeded");
    }
    var quiz = new Quiz
    {
      Title = quizDTO.Title,
      Description = quizDTO.Description,
      CreatedBy = quizDTO.CreatedBy,
      CreatedAt = DateTime.UtcNow,
      UpdatedAt = DateTime.UtcNow,
      Tags = quizDTO.Tags.Select(t => new Tag
      {
        TagName = t
      }).ToList(),
      Questions = quizDTO.Questions.Select(q => new Question
      {
        Example = q.Example,
        QuestionText = q.QuestionText,
        QuestionOptions = q.Options.Select(opt => new QuestionOption
        {
          OptionText = opt.OptionText,
          IsAnswer = opt.isAnswer,

        }).ToList()
      }).ToList()
    };
    Console.WriteLine("TIME RECORDED*******" + quiz.CreatedAt);
    return await _quizRepository.CreateQuiz(quiz);
  }



  public async Task<Quiz> GetQuiz(string userId, int id)
  {
    if (id == 0)
    {
      throw new Exception("Invalid id");
    }
    return await _quizRepository.GetQuiz(id);
  }

  ///////
  public async Task<Quiz> DeleteQuiz(int id)
  {
    if (id == 0)
    {
      throw new Exception("Invalid id");
    }
    return await _quizRepository.DeleteQuiz(id);
  }
}