using artNet.Models;
using artNet.Services;
using artNet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace artNet.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IMuralService _muralService;
        private readonly IComentarioService _comentarioService;

        public DetailsController(IMuralService muralService, IComentarioService comentarioService)
        {
            _muralService = muralService;
            _comentarioService = comentarioService;
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
        public async Task<IActionResult> DetailsExit()
        {
            return RedirectToAction("Index", "Murales");
        }


    }

}
