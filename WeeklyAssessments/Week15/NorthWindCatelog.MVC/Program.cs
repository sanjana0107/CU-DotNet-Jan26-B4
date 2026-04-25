namespace NorthWindCatelog.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register IHttpClientFactory and a named client configured from appsettings.json ("ApiBaseUrl")
            builder.Services.AddHttpClient("API",client =>
            {
                client.BaseAddress = new Uri("https://localhost:7001");
            });
        
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Show detailed errors while debugging
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Summary}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
