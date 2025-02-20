using AutoMapper;
using Cinema.API.Controllers;
using DAL.Models.Domain;
using DAL.Models.DTOs.Genre;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectTests
{
    public class GenreTests
    {
        private readonly Mock<IGenreRepository> mockGenreRepository;
        private readonly Mock<IMapper> mockMapper;
        private readonly GenresController genresController;

        public GenreTests()
        {
            mockGenreRepository = new Mock<IGenreRepository>();
            mockMapper = new Mock<IMapper>();
            genresController = new GenresController(mockMapper.Object, mockGenreRepository.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnGenres()
        { 
            // Arrange
            var genres = new List<Genre>
            {
                new Genre { GenreId = 1, GenreName = "Action" },
                new Genre { GenreId = 2, GenreName = "Comedy" }
            };
            mockGenreRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(genres);
            mockMapper.Setup(m => m.Map<List<GenreDto>>(It.IsAny<List<Genre>>())).Returns(new List<GenreDto>
            {
                new GenreDto { GenreId = 1, GenreName = "Action" },
                new GenreDto { GenreId = 2, GenreName = "Comedy" }
            });

            // Act
            var result = await genresController.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnGenres = Assert.IsType<List<GenreDto>>(okResult.Value);
            Assert.Equal(2, returnGenres.Count);
        }

        [Fact]
        public async Task GetById_ShouldReturnGenre_WhenGenreExists()
        {
            // Arrange
            var genre = new Genre { GenreId = 1, GenreName = "Action" };
            mockGenreRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(genre);
            mockMapper.Setup(m => m.Map<GenreDto>(It.IsAny<Genre>())).Returns(new GenreDto { GenreId = 1, GenreName = "Action" });

            // Act
            var result = await genresController.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnGenre = Assert.IsType<GenreDto>(okResult.Value);
            Assert.Equal(1, returnGenre.GenreId);
            Assert.Equal("Action", returnGenre.GenreName);
        }

        [Fact]
        public async Task GetById_ShouldReturnNotFound_WhenGenreDoesNotExist()
        {
            // Arrange
            mockGenreRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Genre)null);

            // Act
            var result = await genresController.GetById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Create_ShouldReturnCreatedGenre()
        {
            // Arrange
            var createGenreDto = new CreateGenreDto { GenreName = "Action" };
            var genre = new Genre { GenreId = 1, GenreName = "Action" };
            mockMapper.Setup(m => m.Map<Genre>(It.IsAny<CreateGenreDto>())).Returns(genre);
            mockGenreRepository.Setup(repo => repo.CreateAsync(It.IsAny<Genre>())).ReturnsAsync(genre);
            mockMapper.Setup(m => m.Map<GenreDto>(It.IsAny<Genre>())).Returns(new GenreDto { GenreId = 1, GenreName = "Action" });

            // Act
            var result = await genresController.Create(createGenreDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnGenre = Assert.IsType<GenreDto>(okResult.Value);
            Assert.Equal(1, returnGenre.GenreId);
            Assert.Equal("Action", returnGenre.GenreName);
        }

        [Fact]
        public async Task Update_ShouldReturnUpdatedGenre_WhenGenreExists()
        {
            // Arrange
            var updateGenreDto = new UpdateGenreDto { GenreName = "Action" };
            var genre = new Genre { GenreId = 1, GenreName = "Action" };
            mockMapper.Setup(m => m.Map<Genre>(It.IsAny<UpdateGenreDto>())).Returns(genre);
            mockGenreRepository.Setup(repo => repo.UpdateAsync(1, It.IsAny<Genre>())).ReturnsAsync(genre);
            mockMapper.Setup(m => m.Map<GenreDto>(It.IsAny<Genre>())).Returns(new GenreDto { GenreId = 1, GenreName = "Action" });

            // Act
            var result = await genresController.Update(1, updateGenreDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnGenre = Assert.IsType<GenreDto>(okResult.Value);
            Assert.Equal(1, returnGenre.GenreId);
            Assert.Equal("Action", returnGenre.GenreName);
        }

        [Fact]
        public async Task Update_ShouldReturnNotFound_WhenGenreDoesNotExist()
        {
            // Arrange
            var updateGenreDto = new UpdateGenreDto { GenreName = "Action" };
            mockMapper.Setup(m => m.Map<Genre>(It.IsAny<UpdateGenreDto>())).Returns(new Genre());
            mockGenreRepository.Setup(repo => repo.UpdateAsync(1, It.IsAny<Genre>())).ReturnsAsync((Genre)null);

            // Act
            var result = await genresController.Update(1, updateGenreDto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnDeletedGenre_WhenGenreExists()
        {
            // Arrange
            var genre = new Genre { GenreId = 1, GenreName = "Action" };
            mockGenreRepository.Setup(repo => repo.DeleteAsync(1)).ReturnsAsync(genre);
            mockMapper.Setup(m => m.Map<GenreDto>(It.IsAny<Genre>())).Returns(new GenreDto { GenreId = 1, GenreName = "Action" });

            // Act
            var result = await genresController.Delete(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnGenre = Assert.IsType<GenreDto>(okResult.Value);
            Assert.Equal(1, returnGenre.GenreId);
            Assert.Equal("Action", returnGenre.GenreName);
        }

        [Fact]
        public async Task Delete_ShouldReturnNotFound_WhenGenreDoesNotExist()
        {
            // Arrange
            mockGenreRepository.Setup(repo => repo.DeleteAsync(1)).ReturnsAsync((Genre)null);

            // Act
            var result = await genresController.Delete(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
