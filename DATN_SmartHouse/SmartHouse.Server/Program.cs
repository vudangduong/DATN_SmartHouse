using Microsoft.EntityFrameworkCore;
using SmartHouse.Entity;
using SmartHouse.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer("Data Source=DESKTOP-KH6N123\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=True; Encrypt=False;"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options =>
            options.WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
