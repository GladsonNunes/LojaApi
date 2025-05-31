using LojaApi.Domain.Core;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly Token _token;

        public AuthController(Token token)
        {
            _token = token;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            // Aqui você faria a verificação no banco
            if (login.Username == "admin" && login.Password == "123")
            {
                var token = _token.GerarToken(login.Username, "admin");
                return Ok(new { token });
            }

            return Unauthorized("Usuário ou senha inválidos.");
        }
    }

    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
