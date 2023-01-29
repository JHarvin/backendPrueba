using BackendPreguntasYRespuestas.Domain.IServices;
using BackendPreguntasYRespuestas.Domain.Models;
using BackendPreguntasYRespuestas.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BackendPreguntasYRespuestas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Usuario usuario) {

            try
            {
                usuario.Password = Encriptar.EncriptarPassword(usuario.Password);
                var user = await _loginService.ValidateUsuario(usuario);

                if (user == null) {
                    return BadRequest(new { mensaje="Usuario o contraseña invalidos" });
                }

                return Ok( new { usuario = user.NombreUsuario });
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        
        }

    }
}
