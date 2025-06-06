﻿using artNet.Domain.Entities;
using artNet.Infraestructure;
using artNet.Services.Interfaces;
using artNet.Models;
using Microsoft.EntityFrameworkCore;

namespace artNet.Services
{
    public class ComentarioService : IComentarioService
    {
        private readonly ApplicationDbContext _context;

        public ComentarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AgregarComentarioAsync(string userId, ComentarioViewModels model)
        {
            var zonaBogota = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            var fechaColombia = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, zonaBogota);
            var comentario = new Comentario
            {
                Contenido = model.Contenido,
                MuralId = model.MuralId,
                UsuarioId = userId,
                Fecha = fechaColombia
            };

            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();
        }


        public async Task<List<ComentarioViewModels>> ObtenerComentariosPorMuralAsync(Guid muralId)
        {
            return await _context.Comentarios
                .Include(c => c.Usuario)
                .Where(c => c.MuralId == muralId)
                .OrderByDescending(c => c.Fecha)
                .Select(c => new ComentarioViewModels
                {
                    Contenido = c.Contenido,
                    Usuario = c.Usuario.UserName,  // ← solo username, no entidad
                    Fecha = c.Fecha
                })
                .ToListAsync();
        }
    }
}
