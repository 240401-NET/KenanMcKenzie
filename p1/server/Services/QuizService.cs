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

  public async Task<Quiz> CreateQuiz(QuizDTO quizDTO)
  {
    var user = await _userRepository.GetUserByName(quizDTO.CreatedBy);

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

    Quiz quiz = new Quiz
    {
      Title = quizDTO.Title,
      Description = quizDTO.Description,
      CreatedBy = user.Id,
      Tags = quizDTO.Tags.Select(tag => new Tag { TagName = tag }).ToList(),
    };

    List<Question> questions = quizDTO.Questions.Select(_questionDTO => new Question
    {
      QuestionText = _questionDTO.QuestionText,
      Example = _questionDTO.Example,
    }).ToList();

    await _quizRepository.SaveChangesAsync();

    return quiz;
  }



  public async Task<Quiz> GetQuiz(int id)
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