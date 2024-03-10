using DerbyCountyAPI.Interfaces;
using DerbyCountyAPI.Models;
using DerbyCountyAPI.Service;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
var DbConnectionString = builder.Configuration["DbConnection"];

// Add services to the container.

builder.Services.AddControllers();
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

app.Run();
