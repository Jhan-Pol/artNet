using artNet.Domain.Entities;
using artNet.Models;
using artNet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace artNet.Controllers
{
    [ApiController]
    [Route("api/publicaciones")]
    public class PublicacionesController : ControllerBase
    {
        private readonly IPublicacionesServices _publicacionesService;

        public PublicacionesController(IPublicacionesServices publicacionesService)
        {
            _publicacionesService = publicacionesService;
        }

public async Task<IActionResult> Index(Guid id) // Add 'id' parameter to the method
        {
            var publicacion = await _publicacionesService.GetByIdAsync(id); // Use the 'id' parameter
            if (publicacion == null)
            {
                return NotFound();
            }

            var viewModel = new PublicacionesViewModel
            {
                Id = publicacion.Id,
                Titulo = publicacion.Titulo,
                Descripcion = publicacion.Descripcion,
                Estado = publicacion.Estado,
                Imagen = publicacion.Imagen,
                ArtistaNombre = publicacion.Artista != null ? $"{publicacion.Artista.Name} {publicacion.Artista.LastName}" : "Desconocido"
            };

            return Views(new List<PublicacionesViewModel> { viewModel }); // Convertir a una lista
        }

        private IActionResult Views(IEnumerable<PublicacionesViewModel> viewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var publicacion = await _publicacionesService.GetByIdAsync(id);
            if (publicacion == null)
            {
                return NotFound();
            }

            var viewModel = new PublicacionesViewModel
            {
                Id = publicacion.Id,
                Titulo = publicacion.Titulo,
                Descripcion = publicacion.Descripcion,
                Estado = publicacion.Estado,
                Imagen = publicacion.Imagen,
                ArtistaNombre = publicacion.Artista != null ? $"{publicacion.Artista.Name} {publicacion.Artista.LastName}" : "Desconocido"
            };

            return Views(new List<PublicacionesViewModel> { viewModel }); // Convertir a una lista
        }

[HttpGet]
        public async Task<IActionResult> GetPublicaciones()
        {
            var publicaciones = await _publicacionesService.GetAllAsync();
            return Ok(publicaciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublicacionById(Guid id)
        {
            var publicacion = await _publicacionesService.GetByIdAsync(id);
            if (publicacion == null)
            {
                return NotFound();
            }
            return Ok(publicacion);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublicacion([FromBody] Publicaciones publicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdPublicacion = await _publicacionesService.CreateAsync(publicacion);
            return CreatedAtAction(nameof(GetPublicacionById), new { id = createdPublicacion.Id }, createdPublicacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublicacion(Guid id, [FromBody] Publicaciones publicacion)
        {
            if (id != publicacion.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _publicacionesService.UpdateAsync(publicacion);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicacion(Guid id)
        {
            var deleted = await _publicacionesService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("usuario/{userId}")]
        public async Task<IActionResult> GetPublicacionesByUserId(Guid userId)
        {
            var publicaciones = await _publicacionesService.GetByUserIdAsync(userId);
            return Ok(publicaciones);
        }

        [HttpGet("estado/{estado}")]
        public async Task<IActionResult> GetPublicacionesByEstado(bool estado)
        {
            var publicaciones = await _publicacionesService.GetByEstadoAsync(estado);
            return Ok(publicaciones);
        }
    }
}
