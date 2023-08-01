using System.Collections.Generic ;
using Microsoft.EntityFrameworkCore;
using File.Database;
using System.Data;
using File.Services.Services.Interfaces;
using File.Services.Services.Implementation;
using File.Database.Repository.Implementation;
using File.Database.Repository.Interface;
using File.Services.Converter.Implementation;
using File.Services.Converter.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IFilesRepository, FilesRepository>();
builder.Services.AddTransient<IFileConverters, FileConverters>() ;

builder.Services.AddScoped<IFileService, FileService>();

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
