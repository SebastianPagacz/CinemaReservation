using CinemaReservation.Application;
using CinemaReservation.Application.Services;
using CinemaReservation.Domain.Infrastrucutre.DataSeeder;
using CinemaReservation.Domain.Infrastrucutrel;
using CinemaReservation.Domain.Repository.Implementations;
using CinemaReservation.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CinemaReservation.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Repositories
            builder.Services.AddScoped<IHallRepository, HallRepository>();
            builder.Services.AddScoped<ISeatRepository, SeatRepository>();
            builder.Services.AddScoped<IShowRepository, ShowRepository>();
            builder.Services.AddScoped<ITicketRepository, TicketRepository>();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("CinemaTestDb"));

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly));

            builder.Services.AddScoped<ISeeder, Seeder>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<ISeeder>();
            await seeder.SeedAsync();

            app.Run();
        }
    }
}
