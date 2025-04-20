using Domain.entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        //adicionar aqui las entidades que se van a usar en la aplicacion
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Artista> Artista { get; set; }
        public DbSet<Mural> Mural { get; set; }
        public DbSet<Reaccion> Reaccion {  get; set; }
    }
}