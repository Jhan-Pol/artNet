using artNet.Models;

namespace artNet.Services.Interfaces
{
    public interface ILikeService
    {
        Task<bool> ToggleLikeAsync(Guid muralId, string userId);
        Task<bool> IsLikedAsync(Guid muralId, string userId);
        Task<int> GetLikesCountAsync(Guid muralId);
        
    }
}
