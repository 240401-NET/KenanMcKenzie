
using server.Data;
using server.Model;
using server.Interface;
using Microsoft.EntityFrameworkCore;
namespace server.Repository;

public class QuizRepository : IQuizRepository
{
  private readonly FreeDbContext _context;
  public QuizRepository(FreeDbContext context)
  {
    _context = context;
  }

  public async Task<Quiz> CreateQuiz(Quiz quiz)
  {
    await _context.Quizzes.AddAsync(quiz);
    await _context.SaveChangesAsync();
    return quiz;
  }
  /*        GET      */
  //all
  public async Task<List<Quiz>> GetQuizzes(int userId)
  {
    var quizzes = _context.Quizzes.ToList();
    return quizzes;
  }

  //one
  public async Task<Quiz> GetQuiz(int id)
  {
    return await _context.Quizzes.Include(u => u.CreatedByNavigation).FirstOrDefaultAsync(q => q.QuizId == id);
  }
}