using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class CarModel
	{
		[Key]
		public Guid CarId { get; set; }

		[Required]
		public string Model { get; set; }

		[Required]
		public string Brand { get; set; }
	}
}