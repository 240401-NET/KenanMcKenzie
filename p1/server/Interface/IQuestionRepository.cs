using server.Model;

namespace server.Repository;

public interface IQuestionRepository
{
  Task<Question> AddQuestionAsync(Question question);
  void AddQuestion(Question question);
}
