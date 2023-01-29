using BackendPreguntasYRespuestas.Domain.IRespositoires;
using BackendPreguntasYRespuestas.Domain.Models;
using BackendPreguntasYRespuestas.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPreguntasYRespuestas.Persistence.Respositories
{
    public class LoginRespository : ILoginRespository
    {
        private readonly ApplicationDbContext _context;
        public LoginRespository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ValidateUsuario(Usuario usuario)
        {
            var user = await _context.Usuario.Where(x=>x.NombreUsuario == usuario.NombreUsuario && x.Password == usuario.Password).FirstOrDefaultAsync();
            return user;
        }
    }
}
