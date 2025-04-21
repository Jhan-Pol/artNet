using artNet.Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Reflection;
using System.Collections.Generic;
using artNet.Domain.Entities.User;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace artNet.Infraestructure
{
    public class ApplicationDbContext(DbContextOptions < ApplicationDbContext > options) : IdentityDbContext(options)
    {
        //adicionar aqui las entidades que se van a usar en la aplicacion
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Artista> Artista { get; set; }
        public DbSet<Mural> Mural { get; set; }
        public DbSet<Reaccion> Reaccion {  get; set; }
        public DbSet<User> User { get; set; }
    }
}