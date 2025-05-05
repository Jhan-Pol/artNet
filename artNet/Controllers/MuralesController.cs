using artNet.Domain.Entities.Mural;
using artNet.Domain.Entities; // Artista
using artNet.Infraestructure;
using artNet.Models;
using artNet.Services; // Importa el servicio
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

public class MuralesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IMuralService _muralService;

    // Inyección de dependencia del servicio
    public MuralesController(ApplicationDbContext context, IMuralService muralService)
    {
        _context = context;
        _muralService = muralService;
    }

    // Visible para todos los usuarios
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var murales = await _context.Murales
            .Select(m => new MuralViewModel
            {
                Id = m.Id,
                Nombre = m.Titulo,
                Descripcion = m.Descripcion
            })
            .ToListAsync();

        return View(murales);
    }

    // Solo para artistas autenticados
    [Authorize(Roles = "Artista")]
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [Authorize(Roles = "Artista")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MuralViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Obtener el email del usuario autenticado desde las claims
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(userEmail))
            {
                ModelState.AddModelError("", "No se pudo obtener el email del usuario autenticado.");
                return View(model);
            }

            // Llamar al servicio para crear el mural
            bool success = await _muralService.CrearMuralAsync(model, userEmail);

            if (success)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Hubo un error al crear el mural.");
                return View(model);
            }
        }

        return View(model);
    }
}
