using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace exe.api.Controllers;

[ApiController]
[Route("api/usuario")]
public class UsuarioController : ControllerBase
{
    [Authorize]
    [HttpGet("perfil")]
    public IActionResult Perfil()
    {
        return Ok(new { mensagem = $"Olá, {User.Identity?.Name}! Você está autenticado." });
    }
}