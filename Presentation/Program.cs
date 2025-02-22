using Application;
using Domain;
using Presentation;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Presentation.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPresentation()
    .AddDomain();

// تنظیمات مربوط به EF Core و دیتابیس
var connectionString = builder.Configuration.GetConnectionString("CleanArchDB");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();


// اضافه کردن ExceptionMiddleware برای مدیریت خطاها
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
