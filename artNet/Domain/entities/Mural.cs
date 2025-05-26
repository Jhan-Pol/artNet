using System.ComponentModel.DataAnnotations;

// Models/Mural.cs
namespace artNet.Domain.Entities.Mural
{
    public class Mural
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string ImagenUrl { get; set; }
        public string Ciudad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ArtistaId { get; set; } // Clave for�nea a IdentityUser
        public Artista Artista { get; set; } // Navegaci�n
    }
}


