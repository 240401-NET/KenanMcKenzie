namespace typeTestWeb.Controller;
using typeTestWeb.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using typeTestWeb.Models;


[ApiController]
[Route("api/[controller]")]
class AppUserController : ControllerBase
{

  private readonly IAppUserRepository _appUserRepository;
  public AppUserController(IAppUserRepository appUserRepository)
  {
    _appUserRepository = appUserRepository;
  }

  [HttpGet]
  public async Task<IActionResult> GetAllAppUsers()
  {
    var users = await _appUserRepository.GetAllUsers();
    return Ok(users);
  }

  [HttpGet("{appUserId}")]
  public async Task<IActionResult> GetAppUserById(int appUserId)
  {
    try
    {
      var user = await _appUserRepository.GetUserById(appUserId);
      return Ok(user);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{userName}")]
  public async Task<IActionResult> GetAppUserByUserName(string userName)
  {
    try
    {
      var user = await _appUserRepository.GetUserByUserName(userName);
      return Ok(user);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public async Task<IActionResult> AddAppUser(AppUser user)
  {
    await _appUserRepository.AddUser(user);
    return Ok();
  }

  [HttpPut]
  public async Task<IActionResult> UpdateAppUser(AppUser user)
  {
    await _appUserRepository.UpdateUser(user);
    return Ok();
  }
}