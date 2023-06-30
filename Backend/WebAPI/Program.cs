using Application;
using Infrastructure;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option => {
    option.AddPolicy(name: "React_Frontend", policy =>
    {
        policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod().Build();
    });
});

builder.Services.AddApplicaticationServices();
builder.Services.AddInfrastructureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("React_Frontend");

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
