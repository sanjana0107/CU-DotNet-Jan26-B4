using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentManagementMVC.Data;
using StudentManagementMVC.Services;
namespace StudentManagementMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);           

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpClient<StudentHttpService>(client => {
                client.BaseAddress = new Uri("https://studentmanagementapp-gbhdawbyb7dhbaa8.eastasia-01.azurewebsites.net/");
                client.Timeout = TimeSpan.FromSeconds(30);
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
