using Xunit;
using Moq;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL.Models.Domain;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Cinema.API.Controllers;
using DAL.Models.DTOs.User;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace ProjectTests
{
    public class UserTest
    {
        private readonly Mock<IUserRepository> mockUserRepository;
        private readonly Mock<IMapper> mockMapper;
        private readonly UsersController usersController;

        public UserTest()  // Constructor to initialize mocks
        {
            mockUserRepository = new Mock<IUserRepository>();
            mockMapper = new Mock<IMapper>();
            usersController = new UsersController(mockMapper.Object, mockUserRepository.Object);
        }

        [Fact]
        public async Task AddressExistsAsync_ShouldReturnTrue_WhenAddressExists()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new MyDbContext(options);
            context.Addresses.Add(new Address { AddressId = 1, Street = "123 Main St", City = "Anytown", Country = "USA" });
            context.SaveChanges();

            var repository = new SQLUserRepository(context);

            // Act
            var result = await repository.AddressExistsAsync(1);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AddressExistsAsync_ShouldReturnFalse_WhenAddressDoesNotExist()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new MyDbContext(options);
            var repository = new SQLUserRepository(context);

            // Act
            var result = await repository.AddressExistsAsync(1);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task Create_ShouldReturnBadRequest_WhenAddressIdIsInvalid()
        {
            // Arrange
            var addUserRequestDto = new AddUserRequestDto
            {
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                Password = "hashedpassword2",
                PostalCodeId = 2,
                RoleId = 2,
                AddressId = 999 // Invalid AddressId
            };

            mockUserRepository.Setup(repo => repo.AddressExistsAsync(It.IsAny<int>())).ReturnsAsync(false);
            mockMapper.Setup(m => m.Map<User>(It.IsAny<AddUserRequestDto>())).Returns(new User());

            // Act
            var result = await usersController.Create(addUserRequestDto);
            
            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid AddressId. The specified address does not exist.", badRequestResult.Value);
        }
    }
}