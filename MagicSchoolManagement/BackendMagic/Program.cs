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
using System.Text;
using BackendMagic.Services.Authentication.Token;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;



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




                //Add Identity services
                builder.Services.AddIdentityCore<IdentityUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<SchoolContext>()
           
                    .AddDefaultTokenProviders();


                // Register the  RoleManagementService
                builder.Services.AddScoped<RoleManagementService>();
                
                

                // register Seedhelpers
                //services.AddScoped<HelpStudentSeeder>();
                //services.AddScoped<HelpHouseElfSeeder>();
                //services.AddScoped<HelpTeacherSeeder>();

                // JWT Configuration
                var jwtSettings = configuration.GetSection("Jwt");
                var issuerSigningKey = configuration["Jwt:IssuerSigningKey"];

                builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                                .AddJwtBearer(options =>
                                {
                                    options.TokenValidationParameters = new TokenValidationParameters
                                    {
                                        ValidateIssuer = true,
                                        ValidateAudience = true,
                                        ValidateLifetime = true,
                                        ValidateIssuerSigningKey = true,
                                        ValidIssuer = jwtSettings["ValidIssuer"],
                                        ValidAudience = jwtSettings["ValidAudience"],
                                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(issuerSigningKey)),
                                        RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
                                    };
                                    options.Events = new JwtBearerEvents
                                    {
                                        OnMessageReceived = context =>
                                        {
                                            context.Token = context.Request.Cookies["jwt"];
                                            return Task.CompletedTask;
                                        }
                                    };
                                });

                // Register repositories
                builder.Services.AddScoped<IHouseRepository, HouseRepository>();
                builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
                builder.Services.AddScoped<IStudentRepository, StudentRepository>();
                builder.Services.AddScoped<IGradeRepository, GradeRepository>();
                builder.Services.AddScoped<IHouseElfRepository, HouseElfRepository>();
                builder.Services.AddScoped<IRoomRepository, RoomRepository>();
                builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();

                // Register services
                builder.Services.AddScoped<IHouseService, HouseService>();
                builder.Services.AddScoped<ITeacherService, TeacherService>();
                builder.Services.AddScoped<IStudentService, StudentService>();
                builder.Services.AddScoped<IHouseElfService, HouseElfService>();
                builder.Services.AddScoped<IRoomService, RoomService>();
                builder.Services.AddScoped<IGradeService, GradeService>();


                builder.Services.AddScoped<IAuthService, AuthService>();
                builder.Services.AddScoped<ITokenManager, TokenManager>();
                // add CORS

                builder.Services.AddCors(options =>
                {
                    options.AddPolicy("AllowSpecificOrigins", builder =>
                    {
                   
                        builder.WithOrigins("http://localhost:5173")    // "http://localhost:5174", "https://localhost:7135/swagger/index.html" ?
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

                app.UseCors("AllowSpecificOrigins");
                //app.UseHttpsRedirection();

                app.UseAuthentication();
                app.UseAuthorization();

                




                app.MapControllers();



                //Seed data
                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<SchoolContext>();

                    //context.Database.Migrate();

                    //SeedData.Initialize(services).GetAwaiter().GetResult();
                }

                using (var scope = app.Services.CreateScope())
                {
                    var roleManagementService = scope.ServiceProvider.GetRequiredService<RoleManagementService>();
                    //   var helpTeacherSeeder = scope.ServiceProvider.GetRequiredService<HelpTeacherSeeder>();
                    //    var helpHouseElfSeeder = scope.ServiceProvider.GetRequiredService<HelpHouseElfSeeder>();
                    //    var helpStudentSeeder = scope.ServiceProvider.GetRequiredService<HelpStudentSeeder>();


                    await roleManagementService.EnsureRolesAndClaimsAsync();
                    //    await helpStudentSeeder.EnsureStudentsAsync(SeedData.Students);
                }

            }



        }
    }
}
