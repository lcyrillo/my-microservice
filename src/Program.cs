using Microsoft.EntityFrameworkCore;
using MyMicroservice.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<MicroDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using(var scope = app.Services.CreateScope())
    {
        var microDbContext = scope.ServiceProvider.GetRequiredService<MicroDbContext>();
        microDbContext.Database.EnsureDeleted();
        microDbContext.Database.EnsureCreated();
        //microDbContext.Seed();
    }

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
