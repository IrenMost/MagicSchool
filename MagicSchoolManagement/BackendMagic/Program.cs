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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using BackendMagic.Services.Authentication;



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

               


                // Add Identity services
                services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<SchoolContext>()
                    .AddDefaultTokenProviders();

                // Register the UserService and RoleManagementService
                 
                services.AddScoped<RoleManagementService>();

                // JWT Configuration
                var jwtSettings = configuration.GetSection("Jwt");
                var issuerSigningKey = configuration["Jwt:IssuerSigningKey"];

                // Register repositories
                builder.Services.AddScoped<IHouseRepository, HouseRepository>();
                builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
                builder.Services.AddScoped<IStudentRepository, StudentRepository>();
                builder.Services.AddScoped<IGradeRepository, GradeRepository>();

                // Register services
                builder.Services.AddScoped<IHouseService, HouseService>();
                builder.Services.AddScoped<ITeacherService, TeacherService>();
                builder.Services.AddScoped<IStudentService, StudentService>();
                builder.Services.AddScoped<IGradeService, GradeService>();

                // add CORS

                builder.Services.AddCors(options =>
                {
                    options.AddDefaultPolicy(builder =>
                    {
                        builder.WithOrigins("http://localhost:5173")
                                .AllowAnyMethod()                      // Allow GET, POST, PUT, DELETE, etc.
                                .AllowAnyHeader()                      // Allow custom headers
                                .AllowCredentials();                   // Allow cookies or other credentials if needed
                    });
                });

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

                app.UseCors();
                app.UseHttpsRedirection();

                app.UseAuthentication();
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

                using (var scope = app.Services.CreateScope())
                {
                    var roleManagementService = scope.ServiceProvider.GetRequiredService<RoleManagementService>();
                    await roleManagementService.EnsureRolesAndClaimsAsync();
                }

            }
            

            
        }
    }
}
