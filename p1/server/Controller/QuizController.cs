using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Model;
using System.Linq;
using System.Collections.Generic;
using System;
using server.Interface;
using server.Repository;
namespace server.Controller;


//controller methods have to be public
//controller action methods cannot be overridden
//controller methods cannot be static
[ApiController]
[Route("/quiz")]
public class QuizController : ControllerBase //ControllerBase is for controllers without ASP views
{
  //will need to move to quizrepository because need to get 'public' quizzes for all users, can't access ALL directly, maybe for later project
  //Register -> post
  private readonly IQuizRepository _quizRepository;
  public QuizController(IQuizRepository quizRepository, FreeDbContext _context)
  {
    _quizRepository = quizRepository;
  }
  //get
  [HttpGet]
  public IActionResult GetAllQuizzesForUser([FromRoute] int id) //controller actions return ActionResults
  {
    var quizzes = _quizRepository.GetQuizzes(id);
    return Ok(quizzes);//200
  }

  [HttpGet("{id}")]
  public IActionResult GetQuizById([FromRoute] int id)
  {
    var quiz = _quizRepository.GetQuiz(id);

    if (quiz == null)
    {
      return NotFound();//404
    }
    return Ok(quiz);
  }
  //post
  //append questions and validate in client.. Can add foreach for questions in quiz verifying
  [HttpPost]
  public async Task<IActionResult> CreateQuiz([FromBody] Quiz quiz)
  {
    if (quiz != null)
    {
      await _quizRepository.CreateQuiz(quiz);
      return Ok("Quiz created successfully");
    }
    else return BadRequest();
  }
}

