using Microsoft.AspNetCore.Mvc;

namespace artNet.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult ProfileArtista()
        {
            return View();
        }

        public IActionResult ProfileUsuario()
        {
            return View();
        }
    }
}
