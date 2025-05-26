using artNet.Models;

namespace artNet.Services.Interfaces
{
    public interface IMuralService
    {
        Task<bool> CrearMuralAsync(MuralViewModel model, string userEmail, IFormFile imagen);
        Task<MuralViewModel?> ObtenerMuralPorIdAsync(Guid id);
        Task<List<MuralViewModel>> ObtenerMuralesConLikes(string username, string ciudad = null);
    }
}
