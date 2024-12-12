using AutoMapper;
using DAL.Models.Domain;
using DAL.Models.DTO;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowtimesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IShowtimeRepository _showtimeRepository;

        public ShowtimesController(IMapper mapper, IShowtimeRepository showtimeRepository)
        {
            _mapper = mapper;
            _showtimeRepository = showtimeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var showtimes = await _showtimeRepository.GetAllAsync();
            return Ok(_mapper.Map<List<ShowtimeDto>>(showtimes));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var showtime = await _showtimeRepository.GetByIdAsync(id);
            if (showtime == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ShowtimeDto>(showtime));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ShowtimeDto showtimeDto)
        {
            var showtime = _mapper.Map<Showtime>(showtimeDto);
            var createdShowtime = await _showtimeRepository.CreateAsync(showtime);
            return Ok(_mapper.Map<ShowtimeDto>(createdShowtime));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ShowtimeDto showtimeDto)
        {
            var showtime = _mapper.Map<Showtime>(showtimeDto);
            var updatedShowtime = await _showtimeRepository.UpdateAsync(id, showtime);
            if (updatedShowtime == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ShowtimeDto>(updatedShowtime));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedShowtime = await _showtimeRepository.DeleteAsync(id);
            if (deletedShowtime == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ShowtimeDto>(deletedShowtime));
        }
    }
}
