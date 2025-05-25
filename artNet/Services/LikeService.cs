using artNet.Domain.Entities;
using artNet.Infraestructure;
using artNet.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace artNet.Services
{
    public class LikeService : ILikeService
    {
        private readonly ApplicationDbContext _context;

        public LikeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ToggleLikeAsync(Guid muralId, string userId)
        {
            var existingLike = await _context.Likes
                .FirstOrDefaultAsync(l => l.MuralId == muralId && l.UserId == userId);

            if (existingLike != null)
            {
                _context.Likes.Remove(existingLike);
                await _context.SaveChangesAsync();
                return false; // Ya no le gusta
            }

            var like = new Like
            {
                Id = Guid.NewGuid(),
                MuralId = muralId,
                UserId = userId
            };

            _context.Likes.Add(like);
            await _context.SaveChangesAsync();
            return true; // Ahora le gusta
        }

        public async Task<bool> IsLikedAsync(Guid muralId, string userId)
        {
            return await _context.Likes.AnyAsync(l => l.MuralId == muralId && l.UserId == userId);
        }

        public async Task<int> GetLikesCountAsync(Guid muralId)
        {
            return await _context.Likes.CountAsync(l => l.MuralId == muralId);
        }
    }
}

