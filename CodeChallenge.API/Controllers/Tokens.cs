using CodeChallenge.API.Configs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CodeChallenge.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TokensController : ControllerBase
{
    private readonly JwtConfiguration _config;

    public TokensController(JwtConfiguration config)
    {
        _config = config;
    }

    [HttpGet("{username}/{password}")]
    public async Task<IActionResult> Get(string username, string password)
    {
        if (username != "username" || password != "password"){
            return Unauthorized("Invalid credentials");
        }

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, username)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config.Issuer,
            audience: _config.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(_config.ExpireDays),
            signingCredentials: creds
        );

        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
    }
}
