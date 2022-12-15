using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ServerAPI.Contracts;
using ServerAPI.Entities.DataTransferObjects;
using ServerAPI.Entities.Models;
using ServerAPI.Repository;

namespace ServerAPI.Controllers
{
   [Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly RepositoryContext _userContext;

     private readonly IConfiguration _config;
    public AuthController(RepositoryContext userContext, IConfiguration config)
    {
        _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
         _config = config;

    }

[AllowAnonymous]

[HttpPost("Login")]
public IActionResult Login([FromBody] UserLogin userlogin)
{
  

  var user = _userContext.UserModels.FirstOrDefault(o => o.Username.ToLower() == 
            userlogin.Username.ToLower() && o.Password ==userlogin.Password);

    
    if (user != null )
{
     var token = Generate(user);
     return Ok(token);
}

    return NotFound("User not found");
}

        private string  Generate(UserModel user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTSettings:securityKey"]));
            var signinCredentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

             var claims = new List<Claim> 
    { 
        new Claim(ClaimTypes.NameIdentifier, user.Username), 
         new Claim(ClaimTypes.Email, user.EmailAddress), 
         new Claim(ClaimTypes.GivenName, user.GivenName), 
        new Claim(ClaimTypes.Name, user.Username), 
        new Claim(ClaimTypes.Surname, user.Surname), 
        new Claim(ClaimTypes.Role, user.Role) 
    };

var token = new JwtSecurityToken(_config["JWTSettings:validIssuer"],
_config["JWTSettings:validAudience"],
        claims: claims,
        expires: DateTime.Now.AddMinutes(500000),
        signingCredentials: signinCredentials
    );
   
    return new JwtSecurityTokenHandler().WriteToken(token);


        }

    }
}












    
    // [HttpPost, Route("login")]
    // public IActionResult Login([FromBody] LoginModel loginModel)
    // {
    //     if (loginModel is null)
    //     {
    //         return BadRequest("Invalid client request");
    //     }
    //     var user = _userContext.LoginModels.FirstOrDefault(u => 
    //         (u.UserName == loginModel.UserName) && (u.Password == loginModel.Password));
    //     if (user is null)
    //         return Unauthorized();

            
    //     var claims = new List<Claim>
    //     {
    //         new Claim(ClaimTypes.Name, loginModel.UserName),
    //         new Claim(ClaimTypes.Role, "Manager")
    //     };
    //     var accessToken = _tokenService.GenerateAccessToken(claims);
    //     var refreshToken = _tokenService.GenerateRefreshToken();
    //     user.RefreshToken = refreshToken;
    //     user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
    //     _userContext.SaveChanges();
    //     return Ok(new AuthenticatedResponse
    //     {
    //         Token = accessToken,
    //         RefreshToken = refreshToken
    //     });
    // }
