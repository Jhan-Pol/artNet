using artNet.Infraestructure;
using artNet.Models;
using Microsoft.EntityFrameworkCore;

public class ArtistaService
{
    private readonly ApplicationDbContext _context;

    public ArtistaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ArtistaViewModel?> GetProfileByEmailAsync(string email)
    {
        var artista = await _context.Artistas.FirstOrDefaultAsync(a => a.email == email);
        if (artista == null) return null;

        return new ArtistaViewModel
        {
            Id = artista.Id,
            Nombre = artista.Name,
            LastName = artista.LastName,
            Age = artista.age,
            City = artista.city,
            Country = artista.country,
            Phone = artista.phone,
            Email = artista.email,
            Bibliografia = artista.Bibliografia,
            Disponibilidad = artista.Disponibilidad,
            Instagram = artista.Instagram,
            ImagenPerfil = artista.photoUrl
        };
    }


    public async Task<bool> UpdateProfileAsync(ArtistaViewModel model)
    {
        var artista = await _context.Artistas.FirstOrDefaultAsync(a => a.Id == model.Id);
        if (artista == null) return false;

        artista.Name = model.Nombre;
        artista.LastName = model.LastName;
        artista.age = model.Age;
        artista.city = model.City;
        artista.country = model.Country;
        artista.phone = model.Phone;
       
        artista.Bibliografia = model.Bibliografia;
        artista.Disponibilidad = model.Disponibilidad;
        artista.Instagram = model.Instagram;
        artista.photoUrl = model.ImagenPerfil;

        await _context.SaveChangesAsync();
        return true;
    }

}
