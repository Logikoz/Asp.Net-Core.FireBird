using Microsoft.EntityFrameworkCore;

using WebApplication1.Models;

namespace WebApplication1.Data
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