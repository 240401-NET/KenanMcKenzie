using typeTestWeb.Models;
using typeTestWeb.Interface;
using Microsoft.EntityFrameworkCore;
namespace typeTestWeb.Repository;

public class AppUserRepository : IAppUserRepository
{
  private readonly FreeDBContext _context;
  public AppUserRepository(FreeDBContext context)
  {
    _context = context;
  }
  public async Task<AppUser> GetUserById(int id)
  {
    try
    {
      var user = await _context.AppUsers.FindAsync(id);
      return user;
    }
    catch (Exception e)
    {
      throw new Exception("User not found", e);
    }
  }
  public async Task<List<AppUser>> GetAllUsers()
  {
    return await _context.AppUsers.ToListAsync();
  }
  public async Task<AppUser> GetUserByUserName(string userName)
  {
    try
    {
      var user = await _context.AppUsers.FirstOrDefaultAsync(u => u.Username == userName);
      return user;
    }
    catch (Exception e)
    {
      throw new Exception("User not found", e);
    }
  }

  public async Task<AppUser> AddUser(AppUser user)
  {
    _context.AppUsers.Add(user);
    await _context.SaveChangesAsync();
    return user;
  }
  public async Task<AppUser> UpdateUser(AppUser user)
  {
    _context.AppUsers.Update(user);
    await _context.SaveChangesAsync();
    return user;
  }
  public async Task DeleteUser(int id)
  {
    var user = await GetUserById(id);
    _context.AppUsers.Remove(user);
    await _context.SaveChangesAsync();
  }
}
