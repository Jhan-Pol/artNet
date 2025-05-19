using System.ComponentModel.DataAnnotations;

namespace artNet.Domain.Entities
{
    public class Admin
    {
        [Key]
        public virtual Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public virtual string Name { get; set; }

        [StringLength(50)]
        public virtual string? LastName { get; set; }

        public virtual string? photoUrl { get; set; }

        public virtual int? age { get; set; }

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