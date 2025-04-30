using artNet.Domain.Entities;
using artNet.Infraestructure;
using artNet.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artNet.Services
{
    public class PublicacionesServices : IPublicacionesServices
    {
        private readonly ApplicationDbContext _context;

        public PublicacionesServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Publicaciones>> GetAllAsync()
        {
            return await _context.Publicaciones.Include(p => p.Artista).ToListAsync();
        }

        public async Task<Publicaciones?> GetByIdAsync(Guid id)
        {
            return await _context.Publicaciones.Include(p => p.Artista).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Publicaciones>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Publicaciones.Where(p => p.ArtistaId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Publicaciones>> GetByEstadoAsync(bool estado)
        {
            return await _context.Publicaciones.Where(p => p.Estado == estado).ToListAsync();
        }

        public async Task<Publicaciones> CreateAsync(Publicaciones publicacion)
        {
            publicacion.Id = Guid.NewGuid();
            _context.Publicaciones.Add(publicacion);
            await _context.SaveChangesAsync();
            return publicacion;
        }

        public async Task<bool> UpdateAsync(Publicaciones publicacion)
        {
            _context.Entry(publicacion).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Publicaciones.Any(p => p.Id == publicacion.Id))
                {
                    return false;
                }
                throw;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var publicacion = await _context.Publicaciones.FindAsync(id);
            if (publicacion == null)
            {
                return false;
            }

            _context.Publicaciones.Remove(publicacion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
