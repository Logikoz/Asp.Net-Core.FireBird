using FireBird.API.Data;
using FireBird.API.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FireBird.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		private readonly DataContext _context;

		public CarsController(DataContext context)
		{
			_context = context;
		}

		// POST: api/Cars
		[HttpPost]
		public async Task<ActionResult<CarModel>> CreateCardAsync(CarModel carModel)
		{
			_context.Cars.Add(carModel);
			await _context.SaveChangesAsync();

			return Created($"api/car", carModel);
		}

		// GET: api/Cars
		[HttpGet]
		public async Task<ActionResult<IEnumerable<CarModel>>> GetCarsAsync()
		{
			return await _context.Cars.ToListAsync();
		}

		// GET: api/Cars/5
		[HttpGet("{id}")]
		public async Task<ActionResult<CarModel>> GetCarAsync(Guid id)
		{
			CarModel carModel = await _context.Cars.SingleOrDefaultAsync(car => car.CarId == id);

			if (carModel is null)
				return NotFound();

			return Ok(carModel);
		}

		// PUT: api/Cars/5
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCarAsync(Guid id, [FromBody] CarModel carModel)
		{
			if (id != carModel.CarId)
				return BadRequest();

			_context.Entry(carModel).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!_context.Cars.Any(e => e.CarId == id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// DELETE: api/Cars/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<CarModel>> DeleteCarAsync(Guid id)
		{
			CarModel carModel = await _context.Cars.SingleOrDefaultAsync(car => car.CarId == id);

			if (carModel is null)
				return NotFound();

			_context.Cars.Remove(carModel);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}