using artNet.Domain.Entities;
using artNet.Domain.Entities.User;
using System.Threading.Tasks;
using artNet.Models;
using static artNet.Models.AutenticacionViewModels;

namespace artNet.Services.Interfaces
{
    public interface IAutenticacionService
    {
        Task<string> RegisterAsync(RegisterRequest request);
        Task<string> LoginAsync(LoginRequest request);
        Task<User?> GetUserByUsernameAsync(string username);
    }
}
