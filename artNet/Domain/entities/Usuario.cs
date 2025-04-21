using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace artNet.Domain.entities
{
    public class Usuario
    {
        [Key]
        public virtual Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public virtual string Name { get; set; }
        [Required]
        [StringLength(50)]
        public virtual string LastName { get; set; }
        public virtual string? photoUrl { get; set; }
        [Required]
        [StringLength(50)]
        public virtual string age { get; set; }
        [Required]
        [StringLength(50)]
        public virtual string city { get; set; }
        [Required]
        [StringLength(50)]
        public virtual string country { get; set; }
        [Required]
        [StringLength(50)]
        public virtual string phone { get; set; }
        [Required]
        [StringLength(50)]
        public virtual string email { get; set; }
    }
}
