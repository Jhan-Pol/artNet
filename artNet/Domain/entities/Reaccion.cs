using System.ComponentModel.DataAnnotations;

namespace artNet.Domain.entities
{
	public class Reaccion()
	{
		[key]
        public virtual Guid Id { get; set; }

		public virtual int? no_likes { get; set; }

		public virtual Guid usuario { get; set; }

		[ForeignKey("usuario")]
        public virtual Usuario? usuario { get; set; }

        public virtual Guid mural { get; set; }

        [ForeignKey("mural")]
        public virtual Mural? mural { get; set; }
    }
}
