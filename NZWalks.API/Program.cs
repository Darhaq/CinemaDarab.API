using DAL.Data;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Cinema.API;
using DAL.Mappings;


var builder = WebApplication.CreateBuilder(args);
// Video source: https://www.udemy.com/course/build-rest-apis-with-aspnet-core-web-api-entity-framework/learn/lecture/36980486#overview
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Configure JWT settings
var jwtSettings = new Jwtsettings();
builder.Configuration.GetSection("JwtSettings").Bind(jwtSettings);
builder.Services.AddSingleton(jwtSettings);

// Configure JWT authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
    };
});

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddScoped<IUserRepository, SQLUserRepository>();
builder.Services.AddScoped<IMovieRepository, SQLMovieRepository>();
builder.Services.AddScoped<IPostalCodeRepository, SQLPostalCodeRepository>();
builder.Services.AddScoped<IGenreRepository, SQLGenreRepository>();
builder.Services.AddScoped<ITheaterHallRepository, SQLTheaterHallRepository>();
builder.Services.AddScoped<IShowtimeRepository, SQLShowtimeRepository>();
builder.Services.AddScoped<IReviewRepository, SQLReviewRepository>();
builder.Services.AddScoped<IAddressRepository, SQLAddressRepository>();
builder.Services.AddScoped<ISeatRepository, SQLSeatRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
                          policy =>
                          {
                              policy.AllowAnyOrigin()
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyAllowSpecificOrigins");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
