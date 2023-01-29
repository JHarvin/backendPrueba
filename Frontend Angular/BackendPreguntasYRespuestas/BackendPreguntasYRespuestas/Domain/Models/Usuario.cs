using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendPreguntasYRespuestas.Domain.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage ="el nombre de usario es requerido")]
        [Column(TypeName ="varchar(20)")]
        public string NombreUsuario { get; set; }
        [Required (ErrorMessage ="La constraseña es requerida")]
        [Column(TypeName = "varchar(65)")]
        public string Password { get; set; }
    }
}
