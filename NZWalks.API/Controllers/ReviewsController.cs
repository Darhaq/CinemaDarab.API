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
    public class ReviewsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;

        public ReviewsController(IMapper mapper, IReviewRepository reviewRepository)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _reviewRepository.GetAllAsync();
            return Ok(_mapper.Map<List<ReviewDto>>(reviews));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ReviewDto>(review));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReviewDto reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);
            var createdReview = await _reviewRepository.CreateAsync(review);
            return Ok(_mapper.Map<ReviewDto>(createdReview));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ReviewDto reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);
            var updatedReview = await _reviewRepository.UpdateAsync(id, review);
            if (updatedReview == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ReviewDto>(updatedReview));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedReview = await _reviewRepository.DeleteAsync(id);
            if (deletedReview == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ReviewDto>(deletedReview));
        }
    }
}
