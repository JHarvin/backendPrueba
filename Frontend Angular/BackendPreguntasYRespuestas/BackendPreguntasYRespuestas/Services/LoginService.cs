using BackendPreguntasYRespuestas.Domain.IRespositoires;
using BackendPreguntasYRespuestas.Domain.IServices;
using BackendPreguntasYRespuestas.Domain.Models;
using System.Threading.Tasks;

namespace BackendPreguntasYRespuestas.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRespository _loginRepository;
        public LoginService(ILoginRespository loginRespository)
        {
            _loginRepository = loginRespository;
        }

        public async Task<Usuario> ValidateUsuario(Usuario usuario)
        {
         return await  _loginRepository.ValidateUsuario(usuario);
        }
    }
}
