using DAL.Data;
using DAL.Models.Domain;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatRepository seatRepository;

        public SeatsController(ISeatRepository seatRepository)
        {
            this.seatRepository = seatRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSeats()
        {
            var seats = await seatRepository.GetAllAsync();
            return Ok(seats);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeatById(int id)
        {
            var seat = await seatRepository.GetByIdAsync(id);
            if (seat == null) return NotFound();
            return Ok(seat);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeat(Seat seat)
        {
            var newSeat = await seatRepository.CreateAsync(seat);
            return CreatedAtAction(nameof(GetSeatById), new { id = newSeat.SeatId }, newSeat);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeat(int id, Seat seat)
        {
            var updatedSeat = await seatRepository.UpdateAsync(id, seat);
            if (updatedSeat == null) return NotFound();
            return Ok(updatedSeat);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeat(int id)
        {
            var deletedSeat = await seatRepository.DeleteAsync(id);
            if (deletedSeat == null) return NotFound();
            return Ok(deletedSeat);
        }
    }
}
