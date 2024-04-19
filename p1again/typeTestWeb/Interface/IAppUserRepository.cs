namespace typeTestWeb.Interface;
using typeTestWeb.Models;
using System.Collections.Generic;


public interface IAppUserRepository
{
  Task<AppUser> GetUserById(int id);
  Task<List<AppUser>> GetAllUsers();
  Task<AppUser> GetUserByUserName(string userName);
  Task<AppUser> AddUser(AppUser user);
  Task<AppUser> UpdateUser(AppUser user);
  Task DeleteUser(int id);
}