using artNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace artNet.Services.Interfaces
{
    public interface IPublicacionesServices
    {
        Task<IEnumerable<Publicaciones>> GetAllAsync();
        Task<Publicaciones?> GetByIdAsync(Guid Id);
        Task<IEnumerable<Publicaciones>> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<Publicaciones>> GetByEstadoAsync(bool estado);
        Task<Publicaciones> CreateAsync(Publicaciones publicacion);
        Task<bool> UpdateAsync(Publicaciones publicacion);
        Task<bool> DeleteAsync(Guid id);
    }
}
