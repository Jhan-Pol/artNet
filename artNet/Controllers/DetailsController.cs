using artNet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace artNet.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IMuralService _muralService;

        public DetailsController(IMuralService muralService)
        {
            _muralService = muralService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDetails(Guid id)
        {
            var mural = await _muralService.ObtenerMuralPorIdAsync(id);

            if (mural == null)
            {
                return NotFound();
            }

            return Json(mural); // Devuelve un JSON con los detalles
        }

        [HttpPost]
        public async Task<IActionResult> DetailsExit()
        {
            return RedirectToAction("Index", "Murales");
        }


    }

}
