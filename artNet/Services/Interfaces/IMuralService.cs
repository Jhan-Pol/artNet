using artNet.Models;
using System.Threading.Tasks;

namespace artNet.Services
{
    public interface IMuralService
    {
        Task<bool> CrearMuralAsync(MuralViewModel model, string userEmail);
    }
}
