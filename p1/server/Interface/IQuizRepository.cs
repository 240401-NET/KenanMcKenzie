using System.Linq;

using server.Model;

namespace server.Interface;

public interface IQuizRepository
{
  Task<Quiz> CreateQuiz(Quiz quiz);
  Task<List<Quiz>> GetQuizzes(int userId);
  Task<Quiz> GetQuiz(int id);
}