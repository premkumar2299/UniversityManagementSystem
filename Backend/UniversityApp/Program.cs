using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MySql.EntityFrameworkCore.Extensions;
using UniversityApp;
using UniversityApp.Entities;
using ums.repository;
using ums.service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDesignTimeServices, MysqlEntityFrameworkDesignTimeServices>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IFacultyRepository, FacultyRepository>();
builder.Services.AddTransient<IFacultyService, FacultyService>();
builder.Services.AddEntityFrameworkMySQL().AddDbContext<umsdbContext>(options => {
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));

    

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
