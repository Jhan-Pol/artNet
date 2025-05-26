
﻿using artNet.Domain.Entities; // Artista

﻿using artNet.Infraestructure;

using artNet.Models;
using artNet.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

public class MuralesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IMuralService _muralService;
    private readonly IWebHostEnvironment _hostEnvironment;

    // Inyección de dependencia del servicio y IWebHostEnvironment
    public MuralesController(ApplicationDbContext context, IMuralService muralService, IWebHostEnvironment hostEnvironment)
    {
        _context = context;
        _muralService = muralService;
        _hostEnvironment = hostEnvironment;
    }

    // Visible para todos los usuarios
    [HttpGet]
    public async Task<IActionResult> Index(string ciudad = null)
    {
        string username = User.Identity.IsAuthenticated ? User.Identity.Name : null;
        var murales = await _muralService.ObtenerMuralesConLikes(username, ciudad);
        return View(murales);
    }


    
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
            bool success = await _muralService.CrearMuralAsync(model, userEmail, model.Imagen);

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
