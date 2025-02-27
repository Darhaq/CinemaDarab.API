﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL.Repositories;
using DAL.Models.Domain;
using DAL.Models.DTOs.User;

namespace Cinema.API.Controllers
{
    // /api/users
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UsersController(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }
        // CREATE User
        // POST: /api/users
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddUserRequestDto addUserRequestDto)
        {
            if (addUserRequestDto == null)
            {
                return BadRequest("Request data is null.");
            }

            if (mapper == null)
            {
                throw new NullReferenceException("Mapper is not initialized.");
            }

            if (userRepository == null)
            {
                throw new NullReferenceException("UserRepository is not initialized.");
            }

            // Map DTO to Domain Model
            var userDomainModel = mapper.Map<User>(addUserRequestDto);

            // Check if the AddressId exists
            var addressExists = await userRepository.AddressExistsAsync(userDomainModel.AddressId);
            if (!addressExists)
            {
                return BadRequest("Invalid AddressId. The specified address does not exist.");
            }

            await userRepository.CreateAsync(userDomainModel);

            // Map Domain model to DTO
            return Ok(mapper.Map<UserDto>(userDomainModel));
        }

        // GET User
        // GET: /api/users

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var usersDomainModel = await userRepository.GetAllAsync();

            // Map Domain Model to DTO
            return Ok(mapper.Map<List<UserDto>>(usersDomainModel));
        }

        // Get User By Id
        // GET; /api/users/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userDomainModel = await userRepository.GetByIdAsync(id);

            if(userDomainModel == null)
            {
                return NotFound();
            }
            // Map Domain Model to DTO
            return Ok(mapper.Map<UserDto>(userDomainModel));
        }

        // Update User By Id
        // PUT: /api/users/{id}
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserRequestDto updateUserRequestDto)
        {
            // Map DTO to Domain Model
            var userDomainModel = mapper.Map<User>(updateUserRequestDto);

            userDomainModel = await userRepository.UpdateAsync(id, userDomainModel);

            if (userDomainModel == null)
            {
                return NotFound();
            }
            // Map Domain Model to DTO

            return Ok(mapper.Map<UserDto>(userDomainModel));
        }

        // Delete User By Id
        // DELETE: /api/users/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedUserDomainModel = await userRepository.DeleteAsync(id);
            if (deletedUserDomainModel == null)
            {  
                return NotFound(); 
            }

            return Ok(mapper.Map<UserDto>(deletedUserDomainModel));

            // Map Domain Model to DTO

        }

    }
}
