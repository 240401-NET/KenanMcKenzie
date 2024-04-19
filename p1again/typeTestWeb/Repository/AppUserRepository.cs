using typeTestWeb.Models;
namespace typeTestWeb.Repository;

public class AppUserRepository
{
  private readonly FreeDBContext _context;
  public AppUserRepository(FreeDBContext context)
  {
    _context = context;
  }
  public async Task<AppUser> GetUserById(int id)
  {
    return await _context.AppUsers.FindAsync(id);
  }
  public async Task<AppUser> GetUserByEmail(string email)
  {
    return await _context.AppUsers.FirstOrDefaultAsync(u => u.Email == email);
  }
  public async Task<AppUser> GetUserByUserName(string userName)
  {
    return await _context.AppUsers.FirstOrDefaultAsync(u => u.UserName == userName);
  }
  public async Task<AppUser> GetUserByUserNameAndPassword(string userName, string password)
  {
    return await _context.AppUsers.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
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
