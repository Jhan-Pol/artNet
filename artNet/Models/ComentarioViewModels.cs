using System.ComponentModel.DataAnnotations;

namespace artNet.Models
{
    public class ComentarioViewModels
    {
        public Guid MuralId { get; set; }
        public string Contenido { get; set; }
        public string Usuario { get; set; }  // username, no entidad
        public DateTime Fecha { get; set; }

    }
}
