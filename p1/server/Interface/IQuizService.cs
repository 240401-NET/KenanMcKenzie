using server.Model;

namespace server.Interface;

public interface IQuizService
{
  Task<Quiz> CreateQuiz(Quiz quiz);
  Task<List<Quiz>> GetQuizzes(int userId);
  Task<Quiz> GetQuiz(int id);
  Task<Quiz> DeleteQuiz(int id);
}
