using server.Model;
using server.Interface;
using server.Data;
using Microsoft.EntityFrameworkCore;
namespace server.Repository;

public class UserRepository : IUserRepository
{
  private readonly FreeDbContext _context;

  public UserRepository(FreeDbContext context)
  {
    _context = context;
  }

  public async Task<User> GetUserByName(string name)
  {

    return await _context.Users.FirstOrDefaultAsync(u => u.Name == name) ?? throw new Exception("User not found");
  }
}