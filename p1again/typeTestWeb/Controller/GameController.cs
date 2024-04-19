namespace typeTestWeb.Controller;
using typeTestWeb.Interface;
using typeTestWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
  private readonly IGameRepository _gameRepository;
  public GameController(IGameRepository gameRepository)
  {
    _gameRepository = gameRepository;
  }

  [HttpGet]
  public async Task<IActionResult> GetAllGames()
  {
    return Ok(_gameRepository.GetAllGamesAsync());
  }


  [HttpGet("{gameId}")]
  public async Task<IActionResult> GetGameById(int gameId)
  {
    try
    {
      var game = await _gameRepository.GetGameByIdAsync(gameId);
      return Ok(game);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
    catch
    {
      return BadRequest("An error occurred.");
    }
  }

  [HttpPost]
  public async Task<IActionResult> AddGame(Game game)
  {
    _gameRepository.AddGameAsync(game);
    return Ok();
  }

  [HttpPut]
  public async Task<IActionResult> UpdateGame(Game game)
  {
    _gameRepository.UpdateGameAsync(game);
    return Ok();
  }

  [HttpDelete("{gameId}")]
  public async Task<IActionResult> DeleteGame(int gameId)
  {
    _gameRepository.DeleteGameAsync(gameId);
    return Ok();
  }

}