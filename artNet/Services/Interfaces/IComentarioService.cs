using artNet.Models;

namespace artNet.Services.Interfaces
{
    public interface IComentarioService
    {
        Task AgregarComentarioAsync(string userId, ComentarioViewModels model);
        Task<List<ComentarioViewModels>> ObtenerComentariosPorMuralAsync(Guid muralId);
    }
}
