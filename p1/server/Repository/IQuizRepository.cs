using System.Linq;

using server.Model;

namespace server.Interface;

public interface IQuizRepository
{
  Task<int> CreateQuiz(Quiz quiz);
  Task<List<Quiz>> GetQuizzes();
  Task<Quiz> GetQuiz(int id);
  Task<List<Quiz>> GetQuizByTag(string tagName);
  Task<Quiz> DeleteQuiz(int id);
  Task<Quiz> AddQuiz(Quiz quiz);
  Task<int> SaveChangesAsync();
  Task<List<Quiz>> GetQuizzesByUser(string userId);
}