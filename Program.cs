using PSP_Web_API.Services;
namespace PSP_Web_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddSingleton<AudioService>();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            { endpoints.MapControllers(); });



            app.Run();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<AudioService>(); // или .AddScoped(), если нужно
            services.AddControllers();
        }
    }
}
