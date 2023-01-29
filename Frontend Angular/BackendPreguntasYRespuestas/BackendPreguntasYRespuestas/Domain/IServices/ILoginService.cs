using BackendPreguntasYRespuestas.Domain.Models;
using System.Threading.Tasks;

namespace BackendPreguntasYRespuestas.Domain.IServices
{
    public interface ILoginService
    {
        Task<Usuario> ValidateUsuario(Usuario usuario);
    }
}
