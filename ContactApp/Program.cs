using ContactsApp.Extensions;
using ContactsApp.Service.Services;
using NLog;

namespace ContactApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            LoggerManager logger = new LoggerManager();

            builder.Services.ConfigureResponseCaching();

            // Add services to the container.
            builder.Services.RegisterDependencies();
            builder.Services.ConfigureMapping();
            builder.Services.ConfigureLoggerService();

            builder.Services.ConfigureSqlContext(builder.Configuration);
            builder.Services.ConfigureRepositoryManager();

            builder.Services.AddAuthentication();
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureJWT(builder.Configuration);


            builder.Services.ConfigureControllers();

            // Learn more about configuring Swagger / OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.ConfigureSwagger();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseResponseCaching();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}