
using Book_Management_Backend.interfaces;
using Book_Management_Backend.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace Book_Management_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<BookDbContext>((optionsbuilder =>
            {
                optionsbuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            }));
            builder.Services.AddScoped<IbookInterface, BookRepository>();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            //builder.Services.AddCors(Options=>
            //{
            //    Options.AddPolicy("MyPolicy", policy =>
            //    {
            //        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

            //    });
            //}        
            //);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //app.UseCors("MyPolicy");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
