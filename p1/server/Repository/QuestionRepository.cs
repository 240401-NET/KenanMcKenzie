using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Model;

namespace server.Repository;

public class QuestionRepository : IQuestionRepository
{
  private readonly FreeDbContext _context;
  public QuestionRepository(FreeDbContext context)
  {
    _context = context;
  }

  //question getting added after quiz creation
  public async Task<Question> AddQuestionAsync(Question question)
  {
    //need to get associated quiz -> ToList().Add(question)
    await _context.Questions.AddAsync(question);
    await _context.SaveChangesAsync();
    return question;
  }
  public void AddQuestion(Question question)
  {
    _context.Questions.Add(question);
  }

}
