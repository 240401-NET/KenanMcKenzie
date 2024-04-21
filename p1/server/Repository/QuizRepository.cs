
using server.Data;
using server.Model;
using server.Interface;
using Microsoft.EntityFrameworkCore;
namespace server.Repository;

public class QuizRepository(FreeDbContext context) : IQuizRepository
{
  private readonly FreeDbContext _context = context;

  public async Task<int> CreateQuiz(Quiz quiz)
  {
    await _context.Quizzes.AddAsync(quiz);
    await _context.SaveChangesAsync();
    return quiz.QuizId;
  }
  /*        GET      */
  //all
  public async Task<List<Quiz>> GetQuizzes()
  {

    var quizzes = _context.Quizzes
    .Include(u => u.CreatedByNavigation)
    .Include(q => q.Tags)
    .Include(q => q.Questions)
    .ThenInclude(q => q.QuestionOptions);
    return await quizzes.ToListAsync();

  }

  //one
  public async Task<Quiz> GetQuiz(int id)
  {
    return await _context.Quizzes.FirstOrDefaultAsync(q => q.QuizId == id) ?? throw new Exception("Quiz not found");
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

  public async Task<Quiz> AddQuiz(Quiz quiz)
  {
    _context.Quizzes.Add(quiz);
    await _context.SaveChangesAsync();

    return quiz;
  }
  public async Task<int> SaveChangesAsync()
  {
    return await _context.SaveChangesAsync();
  }
}