using System.ComponentModel.DataAnnotations;

namespace WebAppAspNetCore.Models
{
	public class QueueMessageModel
	{
		[Required]
		public string Text { get; set; }
	}
}