using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PetsController(ApplicationContext context)
        {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<Pet> GetPets()
        {
            return _context.Pets.Include(p => p.petOwner).OrderBy(p => p.name).ToArray();
        }

        [HttpGet("{id}")]
        public Pet getPetById(int id)
        {
            Pet myLittlestPet = _context.Pets
                .Include(p => p.petOwner)
                .SingleOrDefault(p => p.id == id);
            return myLittlestPet;
        }

        [HttpPost]
        public IActionResult addNewMyLittlestPet([FromBody] Pet myLittlestPet)
        {
            _context.Add(myLittlestPet);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(getPetById), //just for sending a header url thingy, doesn't !not call function.
                new { id = myLittlestPet.id },
                myLittlestPet
            );
        }

        [HttpPut("{id}")]
        public IActionResult updatePet([FromBody] Pet pet, int id)
        {
            if (pet.id != id)
                return BadRequest();

            Boolean found = _context.Pets.Any(b => b.id == id);
            if (!found)
                return NotFound();

            _context.Pets.Update(pet);
            _context.SaveChanges();
            return Ok(pet);
        }

        [HttpDelete("{id}")]
        public IActionResult deletePetById(int id)
        {
            Pet myBiggestPet = _context.Pets.SingleOrDefault(p => p.id == id);

            if (myBiggestPet == null)
                return NotFound();

            _context.Pets.Remove(myBiggestPet);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}/checkin")]
        public IActionResult checkInPet(int id)
        {
            Pet myBiggestPet = _context.Pets.SingleOrDefault(p => p.id == id);
            //myBiggestPet wasn't bread, soylent green is people!
            if (myBiggestPet == null)
                return NotFound();

            myBiggestPet.checkIn();

            _context.Pets.Update(myBiggestPet);
            _context.SaveChanges();
            return Ok(myBiggestPet);
        }

        [HttpPut("{id}/checkout")]
        public IActionResult checkOutPet(int id)
        {
            Pet myBiggestPet = _context.Pets.SingleOrDefault(p => p.id == id);
            //myBiggestPet wasn't bread, soylent green is people!
            if (myBiggestPet == null)
                return NotFound();

            myBiggestPet.checkOut();

            _context.Pets.Update(myBiggestPet);
            _context.SaveChanges();
            return Ok(myBiggestPet);
        }
    }
}
