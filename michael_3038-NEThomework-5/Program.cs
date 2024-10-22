using michael_3038_WebApiHomework.Filters;
using Microsoft.AspNetCore.Mvc;
namespace michael_3038_WebApiHomework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the IoC container.
            builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            builder.Services.AddControllers(options => {
                options.Filters.Add<ActionFilter>();
                options.Filters.Add<CustomExceptionFilter>(); 
                options.Filters.Add<ResultFilter>();
            });
            // Configure the HTTP request pipeline.
            var app = builder.Build();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
