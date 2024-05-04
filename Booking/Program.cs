
using BookingHotel.Core.Context;
using Microsoft.EntityFrameworkCore;

namespace BookingHotel {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //config database 
            string connnectionString = builder.Configuration.GetConnectionString("SQLConnection");

            builder.Services.AddDbContext<BookingHotelDbContext>(opts =>
            {
                // Set up connection string for db context
                opts.UseSqlServer(connnectionString);
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
