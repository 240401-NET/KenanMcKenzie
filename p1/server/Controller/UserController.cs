
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using server.Model;
using p1.Model;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace server.Controller;

[ApiController]
[Route("api/[controller]")]
public class UserController(SignInManager<User> _signInManager, UserManager<User> _userManager) : ControllerBase
{
  private readonly SignInManager<User> signInManager = _signInManager; //api for user sign in https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.signinmanager-1?view=aspnetcore-8.0
  private readonly UserManager<User> userManager = _userManager;//handles user persistence https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.usermanager-1?view=aspnetcore-8.0

  [HttpPost("register")]
  public async Task<ActionResult> Register(User user)
  {
    string message;
    IdentityResult result = new();
    try
    {
      User _user = new User()
      {
        Name = user.Name,
        Email = user.Email,
        UserName = user.UserName,
      };
      result = await userManager.CreateAsync(_user, user.PasswordHash); //no password needed
      if (!result.Succeeded)
      {
        return BadRequest(result);
      }
      message = "New user added";
    }
    catch (Exception e)
    {
      return BadRequest("Error creating user: " + e.Message);
    }
    return Ok(new { message = message, result = result });
  }
  [HttpPost("login")]
  public async Task<ActionResult> SignIn(Login loginAttempt)
  {
    try
    {
      User _user = await userManager.FindByEmailAsync(loginAttempt.Email);
      if (_user != null)
      {
        loginAttempt.Username = _user.UserName;
        if (!_user.EmailConfirmed)
        {
          _user.EmailConfirmed = true;
        }

        //(TUser user, string password, bool isPersistent, bool lockoutOnFailure);
        var result = await signInManager.PasswordSignInAsync(_user, loginAttempt.Password, loginAttempt.Remember, false);
        if (!result.Succeeded)
        {
          return Unauthorized("Email or password was incorrect, please try again");
        }
        var updated = await userManager.UpdateAsync(_user);
      }
      else
      {
        return BadRequest(new { message = "User not found" });
      }
    }
    catch (Exception e)
    {
      return BadRequest(new { message = "Error logging in: " + e.Message });
    }
    return Ok(new { message = "Login successful" });
  }

  [HttpGet("logout"), Authorize]//Authorize refers to having a cookie/token
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

  [HttpGet("verify"), Authorize]
  public async Task<ActionResult> VerifyUser()
  {
    string message = "Logged in";
    User currentUser = new();
    try
    {
      var _user = HttpContext.User;
      var principal = new ClaimsPrincipal(_user);
      var result = signInManager.IsSignedIn(principal);
      if (result)
      {
        currentUser = await signInManager.UserManager.GetUserAsync(principal);
      }
      else
      {
        return Forbid("Not authorized to view this page");
      }
    }
    catch (Exception e)
    {
      return BadRequest("Error verifying user: " + e.Message);
    }
    return Ok(new { message, user = currentUser });
  }




}

