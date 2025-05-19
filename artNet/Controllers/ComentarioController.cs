using artNet.Domain.Entities;
using artNet.Models;
using artNet.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace artNet.Controllers
{
    public class ComentarioController : Controller
    {
        private readonly IComentarioService _comentarioService;

        public ComentarioController(IComentarioService comentarioService)
        {
            _comentarioService = comentarioService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Crear(ComentarioViewModels model)
        {
            int userId = int.Parse(User.FindFirst("id").Value); // Ajusta si usas otro claim

            if (ModelState.IsValid)
            {
                await _comentarioService.AgregarComentarioAsync(userId, model);
            }

            return RedirectToAction("Details", "Mural", new { id = model.MuralId });
        }
    }
}
