using BackendMagic.Services;
using BackendMagic.Repository;
using BackendMagic.Data;
using Microsoft.EntityFrameworkCore;
using BackendMagic.Repository.Interfaces;
using Microsoft.Win32;
using BackendMagic.Services.Interfaces;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using BackendMagic.Model;



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
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                
                // db Context 
                builder.Services.AddDbContext<SchoolContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
                

                // Register repositories
                builder.Services.AddScoped<IHouseRepository, HouseRepository>();
                builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
                builder.Services.AddScoped<IStudentRepository, StudentRepository>();

                // Register services
                builder.Services.AddScoped<IHouseService, HouseService>();
                builder.Services.AddScoped<ITeacherService, TeacherService>();
                builder.Services.AddScoped<IStudentService, StudentService>();

              

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
                    var context = services.GetRequiredService<SchoolContext>();

                    context.Database.Migrate();
                
                    SeedData.Initialize(services).GetAwaiter().GetResult();
                }

                //using (var scope = app.Services.CreateScope())
                //{
                //    var services = scope.ServiceProvider;
                //    await SeedData.Initialize(services
                //}

            }
            

            
        }
    }
}
