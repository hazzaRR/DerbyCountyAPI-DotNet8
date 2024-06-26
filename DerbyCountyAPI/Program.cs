using DerbyCountyAPI.Dto;
using DerbyCountyAPI.Interfaces;
using DerbyCountyAPI.Models;
using DerbyCountyAPI.Service;
using DerbyCountyAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;

var allowedOrigins = "allowedOrigins";

var builder = WebApplication.CreateBuilder(args);
var DbConnectionString = builder.Configuration.GetConnectionString("DbConnection");



// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins,
    policy =>
    {
        policy
        .WithOrigins("http://localhost:3000", "https://derby-county.harryredman.com")
        .AllowAnyHeader()
        .AllowAnyMethod();

    });

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var Configuration = builder.Configuration;
builder.Services.AddDbContext<DerbycountyContext>(options =>
        options.UseNpgsql(DbConnectionString));


builder.Services.AddScoped<ILeagueTableService, LeagueTableService>();
builder.Services.AddScoped<IMatchResultService, MatchResultService>();
builder.Services.AddScoped<IUpcomingFixtureService, UpcomingFixtureService>();

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

app.UseCors(allowedOrigins);

app.Run();
