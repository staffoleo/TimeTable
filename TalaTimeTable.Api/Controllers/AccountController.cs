using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TalaTimeTable.Api.Models;
using TalaTimeTable.Api.Models.AccountViewModels;

namespace TalaTimeTable.Api.Controllers
{
  [Authorize]
  [Route("api/Account")]
  public class AccountController : Controller
  {
    private readonly UserManager<ApplicationUser> _userManager;

    private readonly ILogger _logger;
    private readonly IConfiguration _configuration;

      public AccountController(UserManager<ApplicationUser> userManager, ILogger<AccountController> logger, IConfiguration configuration)
    {
      _userManager = userManager;
      _logger = logger;
      _configuration = configuration;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    //[ValidateAntiForgeryToken]
    public IActionResult Login([FromBody] LoginViewModel model)
    {
      if (ModelState.IsValid)
      {
        var claims = new[]
        {
          new Claim(JwtRegisteredClaimNames.Email, model.Email),
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var expiration = DateTime.UtcNow.AddDays(1);
        var token = new JwtSecurityToken
        (
          claims: claims,
          expires: expiration,
          notBefore: DateTime.UtcNow,
          signingCredentials:
          new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:JwtSigningKey"])),
            SecurityAlgorithms.HmacSha256)
        );
        return Ok(new {token = new JwtSecurityTokenHandler().WriteToken(token), validity = expiration});
      }
      return BadRequest();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
    {
      if (ModelState.IsValid)
      {
        var user = new ApplicationUser {UserName = model.Email, Email = model.Email};
        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
          _logger.LogInformation("User created a new account with password.");
          return Ok();
        }
      }

      return BadRequest();
    }
  }
}
