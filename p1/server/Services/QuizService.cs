using server.Interface;
using server.Model;
using server.Repository;

namespace server.Service;

public class QuizService : IQuizService
{
  private readonly IQuizRepository _quizRepository;
  private readonly IUserRepository _userRepository;
  private readonly IQuestionRepository _questionRepository;
  public QuizService(IQuizRepository quizRepository, IUserRepository userRepository, IQuestionRepository questionRepository)
  {
    _questionRepository = questionRepository;
    _quizRepository = quizRepository;
    _userRepository = userRepository;
  }

  public async Task<Quiz> CreateQuiz(QuizDTO quizDto)
  {
    var user = await _userRepository.GetUserByName(quizDto.CreatedBy);

    if (quizDto.Questions.Count == 0)
    {
      throw new FormatException("Quiz must have at least one question");
    }
    if (quizDto.Title.Length == 0 || quizDto.Title == null)
    {
      throw new FormatException("Quiz must have a title");
    }
    if (quizDto.Tags.Count > 3)
    {
      throw new FormatException("Maximum number of tags exceeded");
    }

    Quiz quiz = new Quiz
    {
      Title = quizDto.Title,
      Description = quizDto.Description,
      CreatedBy = user.Id,
      Tags = quizDto.Tags.Select(tag => new Tag { TagName = tag }).ToList(),
    };

    var newQuiz = await _quizRepository.CreateQuiz(quiz);

    foreach (var question in quizDto.Questions)
    {
      question.BelongsToNavigation = newQuiz;
      await _questionRepository.AddQuestionAsync(question);
    }

    return newQuiz;
  }

  public async Task<List<Quiz>> GetQuizzes(int userId)
  {

    return await _quizRepository.GetQuizzes(userId);
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