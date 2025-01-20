using AutoMapper;
using DAL.Models.Domain;
using DAL.Models.DTOs.Genre;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IGenreRepository genreRepository;

        public GenresController(IMapper mapper, IGenreRepository genreRepository)
        {
            this.mapper = mapper;
            this.genreRepository = genreRepository;
        }

        // GET Genre
        // GET: /api/genres

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genreDomainModel = await genreRepository.GetAllAsync();

            // Map Domain Model to DTO
            return Ok(mapper.Map<List<GenreDto>>(genreDomainModel));
        }

        // Get Genre By Id
        // GET; /api/genres/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var genreDomainModel = await genreRepository.GetByIdAsync(id);

            if (genreDomainModel == null)
            {
                return NotFound();
            }
            // Map Domain Model to DTO
            return Ok(mapper.Map<GenreDto>(genreDomainModel));
        }

        // Create Genre
        // POST: /api/genres
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGenreDto createGenreDto)
        {
            var genreDomainModel = mapper.Map<Genre>(createGenreDto);
            var createdGenre = await genreRepository.CreateAsync(genreDomainModel);
            return Ok(mapper.Map<GenreDto>(createdGenre));
        }

        // Update Genre
        // PUT: /api/genres/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateGenreDto updateGenreDto)
        {
            var genreDomainModel = mapper.Map<Genre>(updateGenreDto);
            var updatedGenre = await genreRepository.UpdateAsync(id, genreDomainModel);
            if (updatedGenre == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<GenreDto>(updatedGenre));
        }

        // Delete Genre
        // DELETE: /api/genres/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedGenre = await genreRepository.DeleteAsync(id);
            if (deletedGenre == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<GenreDto>(deletedGenre));
        }
    }
}

