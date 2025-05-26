using artNet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class ProfileController : Controller
{
    private readonly ArtistaService _artistaService;

    public ProfileController(ArtistaService artistaService)
    {
        _artistaService = artistaService;
    }

    [Authorize]
    public async Task<IActionResult> Profile()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        if (string.IsNullOrEmpty(email)) return RedirectToAction("Login", "Account");

        var model = await _artistaService.GetProfileByEmailAsync(email);
        if (model == null) return View("Error");

        return View(model);
    }

    [Authorize]
    public async Task<IActionResult> EditProfile()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var model = await _artistaService.GetProfileByEmailAsync(email);
        return View(model);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> EditProfile(ArtistaViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var success = await _artistaService.UpdateProfileAsync(model);
        if (success)
            return RedirectToAction("Profile");
        else
            return View("Error");
    }
}
