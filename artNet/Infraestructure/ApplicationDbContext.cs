<<<<<<< HEAD
﻿using artNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Reflection;
using System.Collections.Generic;

using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

=======
﻿using artNet.Domain.entities;
using artNet.Domain.Entities.Mural;
using artNet.Domain.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
>>>>>>> dev/aguirre

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
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}