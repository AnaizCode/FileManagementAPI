using System.Collections.Generic ;
using Microsoft.EntityFrameworkCore;
using System.Data;
using FileManagementAPI.Database.Repository.Implementation;
using FileManagementAPI.Database.Repository.Interface;
using FileManagementAPI.Services.Services.Interfaces;
using FileManagementAPI.Services.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IFilesRepository, FilesRepository>();
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
