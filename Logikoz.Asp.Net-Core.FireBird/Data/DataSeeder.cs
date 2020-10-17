using System;
using System.Linq;

using FireBird.API.Models;

namespace FireBird.API.Data
{
	public class DataSeeder
	{
		private readonly DataContext _context;

		public DataSeeder(DataContext context)
		{
			_context = context;
		}

		public void Init()
		{
			InitPersons();
		}

		//private void InitCars()
		//{
		//	if(_context.Cars.Count() <= 0)
		//	{
		//		_context.Cars.Add(new CarModel
		//		{
		//			Brand = "Gol",
		//			Model = "1.0"
		//		});

		//		_context.SaveChanges();
		//	}
		//}

		private void InitPersons()
		{
			if (_context.Persons.Count() <= 0)
			{
				_context.Persons.Add(new PersonModel
				{
					Name = "Maria Joana da Silva Santos",
					CPF = "28629001097",
					BirthDate = DateTime.Parse("2001-02-15"),
					Height = 1.87
				});

				_context.SaveChanges();
			}
		}
	}
}