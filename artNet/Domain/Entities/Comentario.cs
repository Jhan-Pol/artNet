using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using artNet.Domain.Entities;
using Microsoft.AspNetCore.Identity;

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

        // Relación con IdentityUser
        [Required]
        public string UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public IdentityUser Usuario { get; set; }

        [Required]
        public Guid MuralId { get; set; }

        public Mural Mural { get; set; }
    }
}

