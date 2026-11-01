using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using exe.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace exe.api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
  
        if (request.Usuario != "admin" || request.Senha != "123456")
        {
            return Unauthorized(); // 401
        }

        var chave = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("minha-chave-secreta-com-no-minimo-32-caracteres"));

        var token = new JwtSecurityToken(
            claims: new[] { new Claim(ClaimTypes.Name, request.Usuario) },
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: new SigningCredentials(chave, SecurityAlgorithms.HmacSha256)
        );

        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}