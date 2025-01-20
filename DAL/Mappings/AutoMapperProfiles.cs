﻿using AutoMapper;
using DAL.Models.Domain;
using DAL.Models.DTO;
using DAL.Models.DTOs.Genre;
using DAL.Models.DTOs.Movie;
using DAL.Models.DTOs.Review;
using DAL.Models.DTOs.TheaterHall;
using DAL.Models.DTOs.TheaterHall.Seat;
using DAL.Models.DTOs.User;

namespace NZWalks.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Users
            CreateMap<UpdateUserRequestDto, User>().ReverseMap();
            CreateMap<AddUserRequestDto, User>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            // PostalCode
            CreateMap<PostalCode, PostalCodeDto>().ReverseMap();

            // Genre
            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Genre, CreateGenreDto>().ReverseMap();
            CreateMap<Genre, UpdateGenreDto>().ReverseMap();

            // Review
            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<Review, CreateReviewDto>().ReverseMap();
            CreateMap<Review, UpdateReviewDto>().ReverseMap();

            // Movie
            CreateMap<Movie, MovieDto>().ReverseMap();

            CreateMap<Showtime, ShowtimeDto>().ReverseMap();

            CreateMap<TheaterHall, TheaterHallDto>().ReverseMap();

            CreateMap<Ticket, TicketDto>().ReverseMap();

            CreateMap<Review, ReviewDto>().ReverseMap();

            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
