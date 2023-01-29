using BackendPreguntasYRespuestas.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendPreguntasYRespuestas.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
    }
}
