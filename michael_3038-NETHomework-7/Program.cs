using Microsoft.EntityFrameworkCore;
using michael_3038EFWebAPI.Data;
using michael_3038EFWebAPI.IService;
using michael_3038EFWebAPI.Service;
using Microsoft.OpenApi.Models;
using System.Reflection;
using NLog.Web;
using Microsoft.AspNetCore.Mvc;
using NLog;
using michael_3038EFWebAPI.Config;
using System.Text;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;



namespace michael_3038EFWebAPI;

public class Program
{
    public static void Main(string[] args)
    {

        // Early init of NLog to allow startup and exception logging, before host is built
        var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
        logger.Debug("init main");
        var policyName = "defalutPolicy";

        try
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddTransient<ICategoryService, CategoryService>();
            builder.Services.AddTransient<ICourseService, CourseService>();

            //配置options方式，后面可以用于依赖注入, 读入db connection 
            builder.Services.Configure<DBConnectionConfig>(builder.Configuration);


            //read database connection string for entity framework
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 18));//data
            var connectionString = builder.Configuration["DBConnection"];
            
            builder.Services.AddDbContext<HomeworkDBContext>(
            dbContextOptions => dbContextOptions
                       .UseMySql(connectionString, serverVersion)
                       // The following three options help with debugging, but should
                       // be changed or removed for production.
                       .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                       .EnableSensitiveDataLogging()
                       .EnableDetailedErrors()
               );
            //this jwtConfig need to be used in this program.cs
            var jWTConfig = builder.Configuration.GetSection("JWTConfig").Get<JWTConfig>();
            builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jWTConfig.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = jWTConfig.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jWTConfig.SecrectKey))
                };
            });
            // register jwt services
            builder.Services.AddTransient<CreateTokenService>();


            //suppress default filters
            builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            // Add services to the container.
            builder.Services.AddControllers();

            //add swagger 
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "My First Web Api Project",
                    Version = "v1",
                    Description = "This is my First Web Api Project",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact() { Name = "michael", Url = new Uri("https://github.com/") }
                });

                var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName), true);

                options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                {
                    Description = "",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                        {
                        {
                        new OpenApiSecurityScheme()
                        {
                            Reference=new OpenApiReference()
                            {
                                 Type=ReferenceType.SecurityScheme,
                                 Id="Bearer"
                            }
                        },
                        new List<string>()
                        }
                        });

            });
            Console.WriteLine("Environment: {0}", builder.Environment.EnvironmentName);

            //nlog
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();

            //Configure the HTTP request pipeline.
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseCors(policyName);

            //swagger
            app.UseSwagger(); // 生成 Swagger 文档
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
        catch (Exception exception)
        {
            // NLog: catch setup errors
            logger.Error(exception, "Stopped program because of exception");
            throw;
        }
        finally
        {
            // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
            NLog.LogManager.Shutdown();

        }
    }
}
