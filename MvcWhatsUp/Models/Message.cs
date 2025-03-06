using System.ComponentModel.DataAnnotations;

namespace MvcWhatsUp.Models
{
	public class Message
	{
		public int Id { get; set; }

		[Required]
		[StringLength(100)]
		public string Content { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.Now;
	}
}
