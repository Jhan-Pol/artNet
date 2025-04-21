using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace artNet.Domain.entities
{
	public class Reaccion
	{
		[Key]
        public virtual Guid Id { get; set; }

		public virtual int? no_likes { get; set; }

		public virtual Guid usuario { get; set; }

		[ForeignKey("usuarioId")]
        public virtual Usuario? usuarioId { get; set; }

        public virtual Guid mural { get; set; }

        [ForeignKey("mural")]
        public virtual Mural? muralId { get; set; }
    }
}
