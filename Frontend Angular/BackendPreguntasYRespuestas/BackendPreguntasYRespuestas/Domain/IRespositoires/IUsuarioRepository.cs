using BackendPreguntasYRespuestas.Domain.Models;
using System.Threading.Tasks;

namespace BackendPreguntasYRespuestas.Domain.IRespositoires
{
    public interface IUsuarioRepository
    {
        Task SaveUser(Usuario usuario);
        Task<bool> ValidateExistence(Usuario usuario);
        Task<Usuario> ValidarPassword(int IdUsuario, string passwordAnterior);
        Task UpdatePassword(Usuario usuario);
    }
}
