﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class PersonModel
	{
		[Key]
		public Guid PersonId { get; set; }

		[Required]
		[MinLength(20)]
		public string Name { get; set; }

		[Required]
		public DateTime? BirthDate { get; set; }

		[Required]
		[Range(1.5, 2.3)]
		public double Height { get; set; }

		[Required]
		[MaxLength(11)]
		[MinLength(11)]
		public string CPF { get; set; }
	}
}