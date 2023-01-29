using BackendPreguntasYRespuestas.Domain.IRespositoires;
using BackendPreguntasYRespuestas.Domain.Models;
using BackendPreguntasYRespuestas.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPreguntasYRespuestas.Persistence.Respositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task SaveUser(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePassword(Usuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> ValidarPassword(int IdUsuario, string passwordAnterior)
        {
            var usuario = await _context.Usuario.Where(x=>x.Id == IdUsuario && x.Password == passwordAnterior).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<bool> ValidateExistence(Usuario usuario)
        {
            var validate = await _context.Usuario.AnyAsync(x => x.NombreUsuario == usuario.NombreUsuario);
            return validate;
        }
    }
}
