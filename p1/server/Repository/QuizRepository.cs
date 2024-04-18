
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
  //GETALL -done
  //GETONE -done
  //GETBYNAME -done
  //POST -done
  //DELETEBYID -done
  //PUTBYID

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
    return await _context.Quizzes.FirstOrDefaultAsync(q => q.QuizId == id);
  }

  public async Task<List<Quiz>> GetQuizByTag(string tagName)
  {
    var quizzes = await _context.Quizzes
    .Include(q => q.Tags)
    .Where(q => q.Tags.Any(t => t.TagName.Equals(tagName, StringComparison.OrdinalIgnoreCase)))
    .ToListAsync();
    foreach (Quiz quiz in quizzes)
    {
      Console.WriteLine(quiz.Title);
    }
    return quizzes;
  }

  public async Task<Quiz> DeleteQuiz(int id)
  {
    var quiz = await _context.Quizzes.FirstOrDefaultAsync(q => q.QuizId == id);
    if (quiz == null)
    {
      throw new Exception("Quiz not found");
    }
    _context.Quizzes.Remove(quiz);
    await _context.SaveChangesAsync();
    return quiz;
  }
}