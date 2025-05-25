using System.ComponentModel.DataAnnotations;

namespace artNet.Models

{
    public class MuralViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string? Descripcion { get; set; }

        [Required]
        public string Ciudad { get; set; }


        public string? UrlImagen { get; set; } // Opcional, porque se llena desde el backend

        public List<ComentarioViewModels> Comentarios { get; set; } = new();

        [Required]
        public IFormFile Imagen { get; set; }
        public bool UsuarioYaDioLike { get; set; }
        public int CantidadLikes { get; set; }
    }

}
