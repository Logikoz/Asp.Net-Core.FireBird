using FireBird.API.Data;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using System.Text.Json;

namespace FireBird.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.AddDbContext<DataContext>(options =>
			{
				options.UseFirebird("database=localhost:test.fdb;user=sysdba;password=numsei",
				optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(DataContext).Assembly.FullName));
			});

			services.AddSwaggerGen(setup =>
			{
				setup.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "FireBird API",
					Description = "Documentaçao da API"
				});
			});

			services.AddScoped<DataSeeder>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataSeeder seeder)
		{
			using (IServiceScope scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			{
				DataContext dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
				dbContext.Database.Migrate();
			}

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				seeder.Init();
			}

			//app.UseHttpsRedirection();

			app.UseRouting();

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.RoutePrefix = "docs";
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "FireBird API");
			});

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapGet("/", async (e) =>
				{
					string[] fullName = typeof(Startup).Assembly.FullName.Split(',');

					await e.Response.WriteAsync(JsonSerializer.Serialize(new
					{
						Status = true,
						Environment = env.EnvironmentName,
						Name = fullName[0],
						Version = fullName[1].Remove(0, 9),
						Docs = $"{e.Request.Scheme}://{e.Request.Host}/docs"
					}));
				});
			});
		}
	}
}