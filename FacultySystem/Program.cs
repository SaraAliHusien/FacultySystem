
using FacultySystem.Core.MiddleWare;
using FacultySystem.Infrastracture;
using FacultySystem.Infrastructure.ApplicationContext;
using FacultySystem.Service;
using FucaltySystem.Core;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FacultySystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            //Add Data base connection 
            builder.Services.AddDbContext<FacultyDbContext>(option =>
            option.UseSqlServer(builder.Configuration.GetConnectionString("FacultySystemDB")));
            //Repositories Services
            builder.Services.AddInfrastructureDepandancies().AddServiceDepandancies().AddCoreDepandancies();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Enable CORS
            var cors = "myPolicy";
            builder.Services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy(cors,
                    CorsPolicyBuilder =>
                    CorsPolicyBuilder.AllowAnyHeader()
                                      .AllowAnyOrigin()
                                      .AllowAnyMethod());
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseHttpsRedirection();
            app.UseCors(cors);
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}