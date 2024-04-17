
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using server.Model;
using p1.Model;
using Microsoft.AspNetCore.Authorization;

namespace server.Controller;

[ApiController]
[Route("/user")]
public class UserController(SignInManager<User> _signInManager, UserManager<User> _userManager) : ControllerBase
{
  //Register -> post
  private readonly SignInManager<User> signInManager; //api for user sign in https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.signinmanager-1?view=aspnetcore-8.0
  private readonly UserManager<User> userManager;//handles user persistence https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.usermanager-1?view=aspnetcore-8.0

  [HttpPost("register")]
  public async Task<ActionResult> Register(User user)
  {
    string message;
    IdentityResult newUser = new();
    try
    {
      User _user = new User()
      {
        Name = user.Name,
        UserName = user.UserName,
        Email = user.Email,
      };
      newUser = await userManager.CreateAsync(_user); //no password needed
      if (!newUser.Succeeded)
      {
        return BadRequest(newUser);
      }
      message = "New user added";
    }
    catch (Exception e)
    {
      return BadRequest("Error creating user: " + e.Message);
    }
    return Ok(new { message, newUser });
  }
  [HttpPost("login")]
  public async Task<ActionResult> SignIn(Login loginAttempt)
  {
    string message;
    try
    {
      User _user = await userManager.FindByEmailAsync(loginAttempt.Email);
      if (_user != null && _user.EmailConfirmed)
      {
        _user.EmailConfirmed = true;
      }
      var result = await signInManager.PasswordSignInAsync(_user, loginAttempt.Password, loginAttempt.Remember, false);
      if (!result.Succeeded)
      {
        return Unauthorized("Email or password was incorrect, please try again");
      }
      var updated = await userManager.UpdateAsync(_user);
      message = "Logged in";
    }
    catch (Exception e)
    {
      return BadRequest("Error logging in: " + e.Message);
    }
    return Ok(new { message });
  }

  [HttpGet("logout"), Authorize]
  public async Task<ActionResult> Logout()
  {
    string message;
    try
    {
      await signInManager.SignOutAsync();
    }
    catch (Exception e)
    {
      return BadRequest("Logout failed, please try again" + e.Message);
    }
    return Ok(new { message = "Logged out successfully" });
  }



}
