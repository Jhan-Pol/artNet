using artNet.Domain.entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Mural
{
    [Key]
    public virtual Guid Id { get; set; }

    [Required]
    [StringLength(50)]
    public virtual string Name { get; set; }

    [Required]
    [StringLength(50)]
    public virtual string Description { get; set; }

    [Required]
    [StringLength(50)]
    public virtual string Location { get; set; }

    [Required]
    public string ImagenUrl { get; set; }

    [Required]
    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    [Required]
    public virtual Guid ArtistaId { get; set; } // Clave foránea

    [ForeignKey("ArtistaId")]
    public virtual Artista? Artista { get; set; } // Propiedad de navegación
}
