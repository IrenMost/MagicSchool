using BackendMagic.Services;
using BackendMagic.Repository;
using BackendMagic.Data;
using Microsoft.EntityFrameworkCore;
using BackendMagic.Repository.Interfaces;
using Microsoft.Win32;
using BackendMagic.Services.Interfaces;


namespace BackendMagic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuration management
            builder.Configuration.AddJsonFile("appsettings.json");
            builder.Configuration.AddUserSecrets<Program>();

            ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();

            ConfigureMiddleware(app);

            app.Run();

            void ConfigureServices(IServiceCollection services, IConfiguration configuration)
            {
                // Add services to the container.
                builder.Services.AddDbContext<SchoolContext>();
                builder.Services.AddControllers();

                // Register repositories
                builder.Services.AddScoped<IHouseRepository, HouseRepository>();
                builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

                // Register services
                builder.Services.AddScoped<IHouseService, HouseService>();
                builder.Services.AddScoped<ITeacherService, TeacherService>();

                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
            }
            async void ConfigureMiddleware(WebApplication app)
            {
                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();


                app.MapControllers();

                // Seed data
                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    SeedData.Initialize(services).GetAwaiter().GetResult();
                }

                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    await SeedData.Initialize(services);
                }

            }
            

            
        }
    }
}
