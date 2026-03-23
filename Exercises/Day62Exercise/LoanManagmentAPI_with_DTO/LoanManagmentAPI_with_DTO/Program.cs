using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LoanManagmentAPI_with_DTO.Data;
using LoanManagmentAPI_with_DTO.Mappings;

namespace LoanManagmentAPI_with_DTO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<LoanManagmentAPI_with_DTOContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("LoanManagmentAPI_with_DTOContext") ?? throw new InvalidOperationException("Connection string 'LoanManagmentAPI_with_DTOContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(MappingProfile));

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
