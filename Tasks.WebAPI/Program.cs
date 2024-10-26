using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Repositories;
using RepositoryContracts;
using ServiceContracts;
using Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

/////////////////////////////////////////////////
// Add services to the container.

builder.Services.AddControllers();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// Tasks Repository
builder.Services.AddScoped<ITasksRepository, TasksRepository>();

// Tasks Service
builder.Services.AddScoped<ITasksService, TasksService>();

/////////////////////////////////////////////////
////////////////////////////////////////////////////

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

/////////////////////////////////////////////////
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/////////////////////////////////////////////////
/////////////////////////////////////////////////
