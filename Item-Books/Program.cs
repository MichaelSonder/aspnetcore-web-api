using Item_Books.Data;
using Item_Books.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var settings = builder.Configuration;
var connectionString = settings.GetConnectionString("DefaultConnectionString");

// AppDbContext added
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

//Configure the Services
builder.Services.AddTransient<BooksService>();

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

// For Seed data
AppDbInitializer.Seed(app);

app.Run();
