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
    public class TicketsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;

        public TicketsController(IMapper mapper, ITicketRepository ticketRepository)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tickets = await _ticketRepository.GetAllAsync();
            return Ok(_mapper.Map<List<TicketDto>>(tickets));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TicketDto>(ticket));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TicketDto ticketDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);
            var createdTicket = await _ticketRepository.CreateAsync(ticket);
            return Ok(_mapper.Map<TicketDto>(createdTicket));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TicketDto ticketDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);
            var updatedTicket = await _ticketRepository.UpdateAsync(id, ticket);
            if (updatedTicket == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TicketDto>(updatedTicket));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedTicket = await _ticketRepository.DeleteAsync(id);
            if (deletedTicket == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TicketDto>(deletedTicket));
        }
    }
}
