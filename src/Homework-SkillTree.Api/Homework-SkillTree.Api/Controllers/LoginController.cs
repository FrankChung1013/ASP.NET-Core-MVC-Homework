using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Homework_SkillTree.Api.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Homework_SkillTree.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class LoginController(IConfiguration configuration) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // 模擬用戶驗證
        if (request.Username != "admin" || request.Password != "password")
        {
            return Unauthorized("Invalid credentials");
        }
        
        var token = GenerateJwtToken(request.Username);
        return Ok(new { token });

    }

    private string GenerateJwtToken(string username)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"] ?? string.Empty));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}