namespace typeTestWeb.Controller;
using typeTestWeb.Interface;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LeaderboardController : ControllerBase
{
  private readonly ILeaderboardRepository _leaderboardRepository;
  public LeaderboardController(ILeaderboardRepository leaderboardRepository)
  {
    _leaderboardRepository = leaderboardRepository;
  }

  [HttpGet]
  public async Task<IActionResult> GetLeaderboard()
  {
    return Ok(_leaderboardRepository.GetLeaderboard());
  }
  [HttpGet("{gameId}")]
  public async Task<IActionResult> GetGameById(int gameId)
  {
    try
    {
      var game = _leaderboardRepository.(gameId);
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

}