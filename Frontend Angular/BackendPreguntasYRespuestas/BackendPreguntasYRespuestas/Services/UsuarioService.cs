using BackendPreguntasYRespuestas.Domain.IRespositoires;
using BackendPreguntasYRespuestas.Domain.IServices;
using BackendPreguntasYRespuestas.Domain.Models;
using System.Threading.Tasks;

namespace BackendPreguntasYRespuestas.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRespository;
        public UsuarioService(IUsuarioRepository usuarioRespository)
        {
            _usuarioRespository = usuarioRespository;       
        }

        public async Task SaveUser(Usuario usuario)
        {
            await _usuarioRespository.SaveUser(usuario);
        }

        public async Task UpdatePassword(Usuario usuario)
        {
            await _usuarioRespository.UpdatePassword(usuario);
        }

        public async Task<Usuario> ValidarPassword(int IdUsuario, string passwordAnterior)
        {
            return await _usuarioRespository.ValidarPassword(IdUsuario, passwordAnterior);
        }

        public async Task<bool> ValidateExistence(Usuario usuario)
        {
          return  await _usuarioRespository.ValidateExistence(usuario);
        }
    }
}
