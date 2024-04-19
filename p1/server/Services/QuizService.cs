using server.Interface;
using server.Model;
using server.Repository;

namespace server.Service;

public class QuizService : IQuizService
{
  private readonly IQuizRepository _quizRepository;
  public QuizService(IQuizRepository quizRepository)
  {
    _quizRepository = quizRepository;
  }

  public async Task<Quiz> CreateQuiz(Quiz quiz)
  {
    if (quiz.Questions.Count == 0 || quiz.Questions == null)
    {
      throw new FormatException("Quiz must have at least one question");
    }
    if (quiz.Title.Length == 0 || quiz.Title == null)
    {
      throw new FormatException("Quiz must have a title");
    }
    if (quiz.Tags.Count > 3)
    {
      throw new FormatException("Maximum number of tags exceeded");
    }


    return await _quizRepository.CreateQuiz(quiz);
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