
using Hotel_Management_Bigbang_Assessment1_.Authentication;
using Hotel_Management_Bigbang_Assessment1_.Models;
using Hotel_Management_Bigbang_Assessment1_.Repository;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_Bigbang_Assessment1_
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


            builder.Services.AddDbContext<HotelDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connection1")));
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connection2")));

            builder.Services.AddControllers().AddNewtonsoftJson(Options => Options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //
            builder.Services.AddScoped<IHotelRepository, HotelRepository>();

            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

            builder.Services.AddScoped<IRoomRepository, RoomRepository>();

            builder.Services.AddScoped<IBookingRepository, BookingRepository>();

            builder.Services.AddScoped<IAmenitiesRepository, AmenitiesRepository>();

            //





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