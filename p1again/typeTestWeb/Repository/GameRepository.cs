namespace typeTestWeb.Repository;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using typeTestWeb.Models;
using typeTestWeb.Interface;

public class GameRepository : IGameRepository
{
  private readonly FreeDBContext _context;

  public GameRepository(FreeDBContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Game>> GetAllGamesAsync()
  {
    return await _context.Games
        .Include(g => g.User)  // Include the User navigation property if needed
        .ToListAsync();
  }

  public async Task<Game?> GetGameByIdAsync(int gameId)
  {
    return await _context.Games
        .Include(g => g.User)  // Include the User navigation property if needed
        .FirstOrDefaultAsync(g => g.GameId == gameId);
  }

  public async Task AddGameAsync(Game game)
  {
    _context.Games.Add(game);
    await _context.SaveChangesAsync();
  }

  public async Task UpdateGameAsync(Game game)
  {
    _context.Entry(game).State = EntityState.Modified;
    await _context.SaveChangesAsync();
  }

  public async Task DeleteGameAsync(int gameId)
  {
    var game = await _context.Games.FindAsync(gameId);
    if (game != null)
    {
      _context.Games.Remove(game);
      await _context.SaveChangesAsync();
    }
  }
}

