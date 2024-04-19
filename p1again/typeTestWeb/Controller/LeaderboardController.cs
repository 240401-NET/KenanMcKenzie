namespace typeTestWeb.Controller;
using typeTestWeb.Interface;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
class LeaderboardController : ControllerBase
{
  private readonly ILeaderboardRepository _leaderboardRepository;
  public LeaderboardController(ILeaderboardRepository leaderboardRepository)
  {
    _leaderboardRepository = leaderboardRepository;
  }

  [HttpGet]
  public IActionResult GetLeaderboard()
  {
    return Ok(_leaderboardRepository.GetLeaderboard());
  }

}