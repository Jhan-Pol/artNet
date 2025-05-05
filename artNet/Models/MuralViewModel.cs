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

        [Required]
        public string UrlImagen { get; set; }
    }

}
