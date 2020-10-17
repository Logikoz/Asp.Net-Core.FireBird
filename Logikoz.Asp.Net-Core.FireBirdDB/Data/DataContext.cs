using Microsoft.EntityFrameworkCore;

using FireBird.API.Models;

namespace FireBird.API.Data
{
	public class DataContext : DbContext
	{
		public DbSet<PersonModel> Persons { get; set; }

		//public DbSet<CarModel> Cars { get; set; }

		public DataContext()
		{
		}

		public DataContext(DbContextOptions options) : base(options)
		{
		}
	}
}