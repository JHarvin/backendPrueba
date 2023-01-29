using BackendPreguntasYRespuestas.Domain.Models;
using System.Threading.Tasks;

namespace BackendPreguntasYRespuestas.Domain.IRespositoires
{
    public interface ILoginRespository
    {
        Task<Usuario> ValidateUsuario(Usuario usuario);
    }
}
