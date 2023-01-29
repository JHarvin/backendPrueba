using BackendPreguntasYRespuestas.Domain.Models;
using System.Threading.Tasks;

namespace BackendPreguntasYRespuestas.Domain.IServices
{
    public interface IUsuarioService
    {
        Task SaveUser(Usuario usuario);
        Task<bool> ValidateExistence(Usuario usuario);
        Task<Usuario> ValidarPassword(int IdUsuario, string passwordAnterior);
        Task UpdatePassword(Usuario usuario);
    }
}
