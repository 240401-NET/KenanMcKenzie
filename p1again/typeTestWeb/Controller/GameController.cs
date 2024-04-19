namespace typeTestWeb.Controller;
using typeTestWeb.Interface;
using typeTestWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using System;

[ApiController]
[Route("api/[controller]")]
class GameController
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
    var game = await _gameRepository.GetGameByIdAsync(gameId);
    if (game is null)
    {
      return BadRequest("Game not found.");
    }
    else
    {
      return Ok(game);
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