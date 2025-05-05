using artNet.Domain.Entities.Mural;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace artNet.Domain.entities
{
    public class Reaccion
    {
        [Key]
        public virtual Guid Id { get; set; }

        public virtual int? no_likes { get; set; }

        // Clave foránea para Usuario
        [Required]
        public virtual Guid UsuarioId { get; set; } // Clave foránea

        [ForeignKey("UsuarioId")]
        public virtual Usuario? Usuario { get; set; } // Propiedad de navegación

        // Clave foránea para Mural
        [Required]
        public virtual Guid MuralId { get; set; } // Clave foránea

        [ForeignKey("MuralId")]
        public virtual Mural? Mural { get; set; } // Propiedad de navegación
    }
}
