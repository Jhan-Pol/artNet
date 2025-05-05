using artNet.Domain.Entities;
using artNet.Domain.Entities.Mural;
using artNet.Infraestructure;
using artNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;

namespace artNet.Services
{
    public class MuralService : IMuralService
    {
        private readonly ApplicationDbContext _context;

        public MuralService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearMuralAsync(MuralViewModel model, string userEmail)
        {
            if (model == null || string.IsNullOrEmpty(userEmail))
            {
                return false;
            }

            // Buscar al artista por su email
            var artista = await _context.Artistas
                .FirstOrDefaultAsync(a => a.email == userEmail);

            if (artista == null)
            {
                return false;
            }

            var mural = new Mural
            {
                Id = Guid.NewGuid(),
                Titulo = model.Nombre,
                Descripcion = model.Descripcion,
                Ciudad = model.Ciudad,
                ImagenUrl = model.UrlImagen, // Esto mantiene la misma lógica
                FechaCreacion = DateTime.UtcNow,
                ArtistaId = artista.Id // Esto también mantiene la misma lógica
            };

            _context.Murales.Add(mural);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
