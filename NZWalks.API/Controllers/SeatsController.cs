using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public SeatsController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllSeats()
        {
            var seats = _context.TheaterHalls
                                .SelectMany(h => h.Seats)
                                .ToList();

            return Ok(seats);
        }

        [HttpPost]
        public IActionResult AddSeat([FromBody] Seat seat)
        {
            _context.Seats.Add(seat);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAllSeats), new { id = seat.SeatId }, seat);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSeat(int id)
        {
            var seat = _context.Seats.Find(id);
            if (seat == null)
                return NotFound();

            _context.Seats.Remove(seat);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

