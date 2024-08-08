
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DbFirstExample.Data;

namespace DbFirstExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DbFirstExampleContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DbFirstExampleContext") ?? throw new InvalidOperationException("Connection string 'DbFirstExampleContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
