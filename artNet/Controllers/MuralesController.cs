using artNet.Domain.Entities.Mural;
using artNet.Domain.Entities; // Artista
using artNet.Infraestructure;
using artNet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

public class MuralesController : Controller
{
    private readonly ApplicationDbContext _context;

    public MuralesController(ApplicationDbContext context)
    {
        _context = context;
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

            // Buscar al artista por su email
            var artista = await _context.Artistas
                .FirstOrDefaultAsync(a => a.email == userEmail);

            if (artista == null)
            {
                ModelState.AddModelError("", "No se encontró un artista asociado a este usuario.");
                return View(model);
            }

            var mural = new Mural
            {
                Id = Guid.NewGuid(),
                Titulo = model.Nombre,
                Descripcion = model.Descripcion,
                Ciudad = model.Ciudad,      // Asocia la ciudad
                ImagenUrl = model.UrlImagen, // Asocia la URL de la imagen
                FechaCreacion = DateTime.UtcNow,
                ArtistaId = artista.Id // Asocia correctamente al artista
            };

            _context.Murales.Add(mural);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }
}

