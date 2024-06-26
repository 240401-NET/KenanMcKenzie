using server.Model;

namespace server.Interface;

public interface IQuizService
{
  Task<int> CreateQuiz(QuizDTO quizDTO);
  Task<Quiz> GetQuiz(string userId, int id);
  Task<Quiz> DeleteQuiz(int id);
}
