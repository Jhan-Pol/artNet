using artNet.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace artNet.Domain.Entities
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
        public Guid ArtistaId { get; set; } 
        public Artista Artista { get; set; } 
        public virtual ICollection<Like> Likes { get; set; }
    }
}
    

