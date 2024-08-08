using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CodeFirstExample.Data;
using CodeFirstExample.Services;

namespace CodeFirstExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<CodeFirstExampleContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CodeFirstExampleContext") ?? throw new InvalidOperationException("Connection string 'CodeFirstExampleContext' not found.")));

            // Add services to the container.
            builder.Services.AddTransient<IJobServices, JobServices>();
            builder.Services.AddTransient<IWorkItemService, WorkItemService>();

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
