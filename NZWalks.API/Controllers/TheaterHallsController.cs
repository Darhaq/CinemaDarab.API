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
    public class TheaterHallsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITheaterHallRepository _theaterHallRepository;

        public TheaterHallsController(IMapper mapper, ITheaterHallRepository theaterHallRepository)
        {
            _mapper = mapper;
            _theaterHallRepository = theaterHallRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var theaterHalls = await _theaterHallRepository.GetAllAsync();
            return Ok(_mapper.Map<List<TheaterHallDto>>(theaterHalls));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var theaterHall = await _theaterHallRepository.GetByIdAsync(id);
            if (theaterHall == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TheaterHallDto>(theaterHall));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TheaterHallDto theaterHallDto)
        {
            var theaterHall = _mapper.Map<TheaterHall>(theaterHallDto);
            var createdTheaterHall = await _theaterHallRepository.CreateAsync(theaterHall);
            return Ok(_mapper.Map<TheaterHallDto>(createdTheaterHall));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TheaterHallDto theaterHallDto)
        {
            var theaterHall = _mapper.Map<TheaterHall>(theaterHallDto);
            var updatedTheaterHall = await _theaterHallRepository.UpdateAsync(id, theaterHall);
            if (updatedTheaterHall == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TheaterHallDto>(updatedTheaterHall));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedTheaterHall = await _theaterHallRepository.DeleteAsync(id);
            if (deletedTheaterHall == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TheaterHallDto>(deletedTheaterHall));
        }
    }
}
