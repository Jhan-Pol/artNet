using artNet.Domain.Entities;
using System.Security.Claims;
using System.Text;
using artNet.Services.Interfaces;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using artNet.Models;
using artNet.Domain.Entities.User;
using static artNet.Models.AutenticacionViewModels;



namespace artNet.Services
{
    public class AutenticacionService : IAutenticacionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public AutenticacionService(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<string> RegisterAsync(RegisterRequest request)
        {
            var user = new User { Username = request.Username, Email = request.Email, PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password) };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return GenerateJwtToken(user);
        }


        public async Task<string> LoginAsync(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Credenciales inválidas.");

            return GenerateJwtToken(user);
        }


        public Task<User?> GetUserByUsernameAsync(string username)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
