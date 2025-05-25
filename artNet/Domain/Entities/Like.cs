using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace artNet.Domain.Entities
{
    public class Like
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid MuralId { get; set; }

        [ForeignKey("MuralId")]
        public virtual Mural Mural { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }
    }
}
