using artNet.Infraestructure;
using artNet.Models;
using artNet.Services;
using artNet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace artNet.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IMuralService _muralService;
        private readonly IComentarioService _comentarioService;
        private readonly ApplicationDbContext _context;

        public DetailsController(IMuralService muralService, IComentarioService comentarioService, ApplicationDbContext context)
        {
            _muralService = muralService;
            _comentarioService = comentarioService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult>GetDetails(Guid id)
        {
            try
            {
                var mural = await _muralService.ObtenerMuralPorIdAsync(id);
                if (mural == null) return NotFound("Mural no encontrado");

                var comentarios = await _comentarioService.ObtenerComentariosPorMuralAsync(id);
                mural.Comentarios = comentarios;

                return Json(mural);
            }
            catch (Exception ex)
            {
                // Devuelve el error como respuesta
                Console.WriteLine("Error al obtener detalles: " + ex.Message);
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AgregarComentario([FromBody] ComentarioViewModels model)
        {
            try
            {
                string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return Unauthorized("No se pudo obtener el ID del usuario autenticado.");
                }

                await _comentarioService.AgregarComentarioAsync(userId, model);

                var comentarios = await _comentarioService.ObtenerComentariosPorMuralAsync(model.MuralId);
                return Json(comentarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al agregar comentario: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DetailsExit()
        {
            return RedirectToAction("Index", "Murales");
        }


    }

}
