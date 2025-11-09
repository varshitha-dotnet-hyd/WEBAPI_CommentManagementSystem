
using Microsoft.EntityFrameworkCore;
using WEBAPI_CommentManagementSystem.Business_Layer.Interfaces;
using WEBAPI_CommentManagementSystem.Business_Layer.Services;
using WEBAPI_CommentManagementSystem.Business_Layer.Services.Repository;
using WEBAPI_CommentManagementSystem.Data;
using WEBAPI_CommentManagementSystem.Filters;

namespace WEBAPI_CommentManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<CustomExceptionFilter>();
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<CommentManagementAppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration
                    .GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<ICommentManagementRepository, CommentManagementRepository>();
            builder.Services.AddScoped<ICommentManagementService, CommentManagementService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
