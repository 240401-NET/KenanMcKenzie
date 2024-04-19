namespace server.Interface;

using server.Model;

public interface IUserRepository
{
  Task<User> GetUserByName(string name);
}