using System;

namespace artNet.Models
{
    public class PublicacionesViewModel
    {
        public Guid Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }
        public string? Imagen { get; set; }
        public string? ArtistaNombre { get; set; } // Nombre del artista relacionado
    }
}
