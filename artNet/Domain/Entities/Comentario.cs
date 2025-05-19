using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using artNet.Domain.Entities;

namespace artNet.Domain.Entities
{
    public class Comentario
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(500, MinimumLength = 5)]
        public string Contenido { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.UtcNow;

        // 🔗 Relación con User (modelo de autenticación)
        [Required]
        public int UsuarioId { get; set; }

        public User Usuario { get; set; }

        // 🔗 Relación con Mural
        [Required]
        public Guid MuralId { get; set; }

        public Mural Mural { get; set; }
    }
}

