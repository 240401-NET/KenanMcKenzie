using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Model;
using server.Interface;
namespace server.Controller;


//controller methods have to be public
//controller action methods cannot be overridden
//controller methods cannot be static
[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase //ControllerBase is for controllers without ASP views
{
  //will need to move to quizrepository because need to get 'public' quizzes for all users, can't access ALL directly, maybe for later project
  //Register -> post
  private readonly IQuizRepository _quizRepository;
  private readonly IQuizService _quizService;
  public QuizController(IQuizRepository quizRepository, FreeDbContext _context, IQuizService quizService)
  {
    _quizRepository = quizRepository;
    _quizService = quizService;
  }
  //get
  //ALL
  [HttpGet]
  public async Task<IActionResult> GetAllQuizzes() //controller actions return ActionResults
  {
    var quizzes = await _quizRepository.GetQuizzes();
    return Ok(quizzes);
  }
  [HttpGet("{userId}")]
  public async Task<IActionResult> GetQuizzesByUser([FromRoute] string userId)
  {
    var quizzes = await _quizRepository.GetQuizzesByUser(userId);
    return Ok(quizzes);
  }
  //ONE
  [HttpGet("{userId}/{id}")]
  public IActionResult GetQuizById([FromRoute] string userId, int id)
  {
    if (id == 0)
    {
      return BadRequest("Invalid id");
    }
    try
    {
      var quiz = _quizService.GetQuiz(userId, id);
      return Ok(quiz);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("tag/{tagName}")]
  public IActionResult GetQuizByTag([FromRoute] string tagName)
  {
    if (tagName == null)
    {
      return BadRequest("Invalid tag");
    }
    try
    {
      var quiz = _quizRepository.GetQuizByTag(tagName);
      return Ok(quiz);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  //post
  //append questions and validate in client.. Can add foreach for questions in quiz verifying
  [HttpPost]
  public async Task<IActionResult> CreateQuiz([FromBody] QuizDTO quiz)
  {
    try
    {
      var quizId = await _quizService.CreateQuiz(quiz);
      return Ok(new { QuizId = quizId });
    }
    catch (Exception ex)
    {
      Console.WriteLine("Error: " + ex.Message);
      return BadRequest("An error occurred creating the quiz");
    }
  }

  [HttpDelete]
  public IActionResult DeleteQuiz([FromRoute] int id)
  {
    if (id == 0)
    {
      return BadRequest("Invalid id");
    }
    try
    {
      var quiz = _quizRepository.DeleteQuiz(id);
      return Ok(quiz);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}

