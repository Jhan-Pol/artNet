using artNet.Domain.Entities.Mural;
using artNet.Infraestructure;
using artNet.Models;
using artNet.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace artNet.Services
{
    public class MuralService : IMuralService
    {
        private readonly ApplicationDbContext _context;

        public MuralService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearMuralAsync(MuralViewModel model, string userEmail, IFormFile imagen)
        {
            if (model == null || string.IsNullOrEmpty(userEmail) || imagen == null)
            {
                return false;
            }

            // Buscar al artista por su email
            var artista = await _context.Artistas
                .FirstOrDefaultAsync(a => a.email == userEmail);

            if (artista == null)
            {
                Console.WriteLine("no");
                return false;
            }

            // Guardar el archivo de imagen en el servidor
            var imagenPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imagen.FileName);

            using (var stream = new FileStream(imagenPath, FileMode.Create))
            {
                await imagen.CopyToAsync(stream);
            }

            // Obtener la URL relativa de la imagen
            var imagenUrl = $"/images/{imagen.FileName}";

            var mural = new Mural
            {
                Id = Guid.NewGuid(),
                Titulo = model.Nombre,
                Descripcion = model.Descripcion,
                Ciudad = model.Ciudad,
                ImagenUrl = imagenUrl,  // Guardar la URL de la imagen
                FechaCreacion = DateTime.UtcNow,
                ArtistaId = artista.Id
            };

            _context.Murales.Add(mural);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<MuralViewModel?> ObtenerMuralPorIdAsync(Guid id)
        {
            var mural = await _context.Murales.FirstOrDefaultAsync(m => m.Id == id);
            if (mural == null) return null;

            return new MuralViewModel
            {
                Id = mural.Id,
                Nombre = mural.Titulo,
                Descripcion = mural.Descripcion,
                Ciudad = mural.Ciudad,
                UrlImagen = mural.ImagenUrl
            };
        }
    }
}
