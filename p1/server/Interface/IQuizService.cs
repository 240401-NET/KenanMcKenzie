using server.Model;

namespace server.Interface;

public interface IQuizService
{
  Task<Quiz> CreateQuiz(QuizDTO quiz);
  Task<Quiz> GetQuiz(int id);
  Task<Quiz> DeleteQuiz(int id);
}
