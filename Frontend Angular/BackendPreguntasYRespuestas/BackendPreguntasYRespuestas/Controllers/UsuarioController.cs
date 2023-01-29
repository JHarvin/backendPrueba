using BackendPreguntasYRespuestas.Domain.IServices;
using BackendPreguntasYRespuestas.Domain.Models;
using BackendPreguntasYRespuestas.DTO;
using BackendPreguntasYRespuestas.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BackendPreguntasYRespuestas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
                _usuarioService = usuarioService;
        }

        [HttpPost("RegistrarUsuario")]
        public async Task<IActionResult> SaveUser([FromBody]Usuario usuario) {
            try { 
            
                var validate = await _usuarioService.ValidateExistence(usuario);
                if (validate) {
                return BadRequest(new {mensaje="El usuario ya existe"});
                }

                usuario.Password = Encriptar.EncriptarPassword(usuario.Password);

                await _usuarioService.SaveUser(usuario);

                return Ok(new { mensaje ="Usuario registrado con exito" });
            

            } catch (Exception e) { 
            return BadRequest(e.Message);
            }


        }

        [HttpPut("CambiarPassword")]
        public async Task<IActionResult> CambiarPassword([FromBody] CambiarPasswordDTO passwordDTO) {

            try
            {
                int idUsuario = 7;
                
                string passwordEncriptado = Encriptar.EncriptarPassword(passwordDTO.PasswordAnterior);
                var usuario = await _usuarioService.ValidarPassword(idUsuario, passwordEncriptado);

                if (usuario == null) {

                    return BadRequest(new { mensaje = "La contraseña anterior no coincide con la ingresada!" });
                
                }

                usuario.Password = Encriptar.EncriptarPassword(passwordDTO.NuevaPassword);
                await _usuarioService.UpdatePassword(usuario);

                return Ok(new { mensaaje="La contraseña se actualizo correctamente" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        
        }
    }

}
