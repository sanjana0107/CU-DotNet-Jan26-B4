using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TravelDestinationAPI.Data;
using TravelDestinationAPI.Repository;
using TravelDestinationAPI.Services;

namespace TravelDestinationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<TravelDestinationAPIContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("TravelDestinationAPIContext") ?? throw new InvalidOperationException("Connection string 'TravelDestinationAPIContext' not found.")));

            // Add services to the container.
      
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddScoped<IDestinationService, DestinationService>();

            builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();

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

            app.Run();
        }
    }
}
