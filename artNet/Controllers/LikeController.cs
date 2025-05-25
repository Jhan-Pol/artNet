using artNet.Domain.Entities;
using artNet.Models;
using artNet.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace artNet.Controllers
{
    [Authorize]
    public class LikeController : Controller
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost]
        public async Task<IActionResult> Toggle([FromBody] LikeViewModels model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }

            bool isLiked = await _likeService.ToggleLikeAsync(model.MuralId, userId);

            return Json(new { isLiked });
        }
    }
}
