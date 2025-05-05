using artNet.Domain.Entities.Mural;
using artNet.Domain.Entities;
using artNet.Infraestructure;
using artNet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using artNet.Services.Interfaces;

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


    }
}
