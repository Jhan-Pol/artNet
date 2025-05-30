﻿using artNet.Domain.Entities;
using artNet.Infraestructure;
using artNet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace artNet.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync(model.Role))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(model.Role));
                    }

                    await _userManager.AddToRoleAsync(user, model.Role);

                    using (var scope = HttpContext.RequestServices.CreateScope())
                    {
                        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                        if (model.Role == "Artista")
                        {
                            var nuevoArtista = new Artista
                            {
                                Id = Guid.NewGuid(),
                                Name = model.UserName,
                                LastName = "",
                                photoUrl = null,
                                age = "",
                                city = "",
                                country = "",
                                phone = "",
                                email = model.Email
                            };
                            context.Artistas.Add(nuevoArtista);
                        }
                        else if (model.Role == "Usuario")
                        {
                            var nuevoUsuario = new Usuario
                            {
                                Id = Guid.NewGuid(),
                                Name = model.UserName,
                                LastName = "",
                                photoUrl = null,
                                age = "",
                                city = "",
                                country = "",
                                phone = "",
                                email = model.Email
                            };
                            context.Usuarios.Add(nuevoUsuario);
                        }
                        else if (model.Role == "Administrador")
                        {
                            var nuevoAdmin = new Admin
                            {
                                Id = Guid.NewGuid(),
                                Name = model.UserName,
                                LastName = "",
                                photoUrl = null,
                                age = 0,
                                city = "",
                                country = "",
                                phone = "",
                                email = model.Email
                            };
                            context.Administradores.Add(nuevoAdmin);
                        }

                        await context.SaveChangesAsync();
                    }

                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Murales");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: true, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Murales");
                    }
                }

                ModelState.AddModelError(string.Empty, "Intento de inicio de sesión inválido.");
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public async Task<IActionResult> ExistAccount()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}
