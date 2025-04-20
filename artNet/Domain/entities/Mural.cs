using System.ComponentModel.DataAnnotations;

namespace artNet.Domain.entities
{
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
        public Guid ArtistaId { get; set; }

        [ForeignKey("ArtistaId")]
        public virtual Artista ? Artista { get; set; }
        }
}
