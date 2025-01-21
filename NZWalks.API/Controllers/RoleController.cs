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
    public class RoleController(IMapper mapper, IRoleRepository roleRepository) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRoleRepository _roleRepository = roleRepository;

        // GET: /api/roles
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleRepository.GetAllAsync();
            return Ok(_mapper.Map<List<RoleDto>>(roles));
        }

        // GET: /api/roles/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RoleDto>(role));
        }

        // POST: /api/roles
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            var createdRole = await _roleRepository.CreateAsync(role);
            return Ok(_mapper.Map<RoleDto>(createdRole));
        }

        // PUT: /api/roles/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] RoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            var updatedRole = await _roleRepository.UpdateAsync(id, role);
            if (updatedRole == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RoleDto>(updatedRole));
        }

        // DELETE: /api/roles/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedRole = await _roleRepository.DeleteAsync(id);
            if (deletedRole == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RoleDto>(deletedRole));
        }
    }
}
