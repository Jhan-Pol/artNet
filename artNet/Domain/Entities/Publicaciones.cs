using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace artNet.Domain.Entities
{
    public class Publicaciones
    {
        public Guid Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }

        public string? Imagen { get; set; } // Propiedad para almacenar la imagen de la publicación  

        // Relación con la tabla de Artista  
        [Required]
        public virtual Guid ArtistaId { get; set; }

        [ForeignKey("ArtistaId")] // Corrige la clave foránea para que coincida con ArtistaId  
        public virtual Artista? Artista { get; set; } // Usa el tipo Artista directamente si está en el espacio de nombres importado  
    }
}
