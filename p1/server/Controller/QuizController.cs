using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Model;
using server.Service;
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
  public IActionResult GetAllQuizzesForUser([FromRoute] int id) //controller actions return ActionResults
  {
    var quizzes = _quizRepository.GetQuizzes(id);
    return Ok(quizzes);
  }
  //ONE
  [HttpGet("{id}")]
  public IActionResult GetQuizById([FromRoute] int id)
  {
    if (id == 0)
    {
      return BadRequest("Invalid id");
    }
    try
    {
      var quiz = _quizService.GetQuiz(id);
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
  public async Task<IActionResult> CreateQuiz([FromBody] Quiz quiz)
  {
    var created = _quizService.CreateQuiz(quiz);
    if (created.IsCompletedSuccessfully)
    {
      return Ok("Quiz created");
    }
    else
    {
      return BadRequest("Quiz not created");
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

