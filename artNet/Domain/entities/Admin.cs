using System.ComponentModel.DataAnnotations;

namespace artNet.Domain.entities
{
    public class Admin
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
        [MaxLength(10)]
        public virtual int age { get; set; }

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