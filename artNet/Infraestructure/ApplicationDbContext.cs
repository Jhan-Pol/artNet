using artNet.Domain.entities;
using artNet.Domain.Entities.Mural;
using artNet.Domain.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace artNet.Infraestructure
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Admin> Administradores { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Mural> Murales { get; set; }
        public DbSet<Reaccion> Reacciones { get; set; }
        public DbSet<User> User { get; set; }
    }
}