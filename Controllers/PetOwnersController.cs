using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PetOwnersController(ApplicationContext context)
        {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPets()
        {
            return _context.PetOwners
            .Include(pet => pet.pets)
            .ToList();
        }

        [HttpGet("{id}")]
        public PetOwner getPetOwnerbyId(int id)
        {
            return _context.PetOwners
            .Include(pet => pet.pets)
            .SingleOrDefault(p => p.id == id);
        }

        [HttpPost]
        public IActionResult addPetOwner([FromBody] PetOwner petOwner)
        {
            _context.PetOwners.Add(petOwner);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getPetOwnerbyId), new { id = petOwner.id }, petOwner);
        }

        [HttpDelete("{id}")]
        public IActionResult deletePetOwnerById(int id)
        {
            PetOwner myLittlestPetOwner = _context.PetOwners.SingleOrDefault(p => p.id == id);
            if (myLittlestPetOwner == null)
            {
                return NotFound();
            }
            _context.PetOwners.Remove(myLittlestPetOwner);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult updatePetOwner([FromBody] PetOwner petOwner, int id) {
            if (petOwner.id != id) return BadRequest();

            Boolean found = _context.PetOwners.Any(b => b.id == id);
            if (!found) return NotFound();

            _context.PetOwners.Update(petOwner);
            _context.SaveChanges();

            return Ok(petOwner);
        }
    }
}
