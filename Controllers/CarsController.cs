using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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

		// GET: api/CarModels
		[HttpGet]
		public async Task<ActionResult<IEnumerable<CarModel>>> GetCars()
		{
			return await _context.Cars.ToListAsync();
		}

		// GET: api/CarModels/5
		[HttpGet("{id}")]
		public async Task<ActionResult<CarModel>> GetCarModel(Guid id)
		{
			var carModel = await _context.Cars.FindAsync(id);

			if (carModel == null)
			{
				return NotFound();
			}

			return carModel;
		}

		// PUT: api/CarModels/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutCarModel(Guid id, CarModel carModel)
		{
			if (id != carModel.CarId)
			{
				return BadRequest();
			}

			_context.Entry(carModel).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!CarModelExists(id))
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

		// POST: api/CarModels
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
		[HttpPost]
		public async Task<ActionResult<CarModel>> PostCarModel(CarModel carModel)
		{
			_context.Cars.Add(carModel);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetCarModel", new { id = carModel.CarId }, carModel);
		}

		// DELETE: api/CarModels/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<CarModel>> DeleteCarModel(Guid id)
		{
			var carModel = await _context.Cars.FindAsync(id);
			if (carModel == null)
			{
				return NotFound();
			}

			_context.Cars.Remove(carModel);
			await _context.SaveChangesAsync();

			return carModel;
		}

		private bool CarModelExists(Guid id)
		{
			return _context.Cars.Any(e => e.CarId == id);
		}
	}
}