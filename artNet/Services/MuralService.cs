<<<<<<< HEAD
﻿using artNet.Domain.Entities;
=======
﻿using artNet.Domain.Entities.Mural;
>>>>>>> dev/aguirre
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

            
            var artista = await _context.Artistas
                .FirstOrDefaultAsync(a => a.email == userEmail);

            if (artista == null)
            {
                Console.WriteLine("no");
                return false;
            }

            
            var imagenPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imagen.FileName);

            using (var stream = new FileStream(imagenPath, FileMode.Create))
            {
                await imagen.CopyToAsync(stream);
            }

            
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
            var mural = await _context.Murales
        .Where(m => m.Id == id)
        .Select(m => new MuralViewModel
        {
            Id = m.Id,
            Nombre = m.Titulo,
            Ciudad = m.Ciudad,
            Descripcion = m.Descripcion,
            UrlImagen = m.ImagenUrl
        })
        .FirstOrDefaultAsync();

            return mural;
        }
        public async Task<List<MuralViewModel>> ObtenerMuralesConLikes(string username, string ciudad = null)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            if (user == null) return new List<MuralViewModel>();

            var query = _context.Murales.AsQueryable();

            if (!string.IsNullOrEmpty(ciudad))
            {
                query = query.Where(m => m.Ciudad == ciudad);
            }

            var murales = await query
                .Select(m => new MuralViewModel
                {
                    Id = m.Id,
                    Nombre = m.Titulo,
                    Ciudad = m.Ciudad,
                    Descripcion = m.Descripcion,
                    UrlImagen = m.ImagenUrl,
                    UsuarioYaDioLike = m.Likes.Any(l => l.UserId == user.Id),
                    CantidadLikes = m.Likes.Count
                })
                .ToListAsync();

            return murales;
        }


    }
}
