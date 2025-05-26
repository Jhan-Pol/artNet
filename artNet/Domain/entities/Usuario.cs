using System.ComponentModel.DataAnnotations;

namespace artNet.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public virtual Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public virtual string Name { get; set; }

        [StringLength(50)]
        public virtual string? LastName { get; set; }

        public virtual string? photoUrl { get; set; }

        [StringLength(50)]
        public virtual string? age { get; set; }

        [StringLength(50)]
        public virtual string? city { get; set; }

        [StringLength(50)]
        public virtual string? country { get; set; }

        [StringLength(50)]
        public virtual string? phone { get; set; }

        [Required]
        [StringLength(50)]
        public virtual string email { get; set; }
    }
}
