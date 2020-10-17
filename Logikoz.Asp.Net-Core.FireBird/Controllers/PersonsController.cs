using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FireBird.API.Data;
using FireBird.API.Models;

namespace FireBird.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonModel>>> GetPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonModel>> GetPersonModel(Guid id)
        {
            var personModel = await _context.Persons.FindAsync(id);

            if (personModel == null)
            {
                return NotFound();
            }

            return personModel;
        }

        // PUT: api/Persons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonModel(Guid id, PersonModel personModel)
        {
            if (id != personModel.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(personModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonModelExists(id))
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

        // POST: api/Persons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PersonModel>> PostPersonModel(PersonModel personModel)
        {
            _context.Persons.Add(personModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonModel", new { id = personModel.PersonId }, personModel);
        }

        // DELETE: api/Persons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonModel>> DeletePersonModel(Guid id)
        {
            var personModel = await _context.Persons.FindAsync(id);
            if (personModel == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(personModel);
            await _context.SaveChangesAsync();

            return personModel;
        }

        private bool PersonModelExists(Guid id)
        {
            return _context.Persons.Any(e => e.PersonId == id);
        }
    }
}