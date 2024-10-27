using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Repositories;
using RepositoryContracts;
using ServiceContracts;
using Services;

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

// CORS - Allow Front End (Live server)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://127.0.0.1:5500")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

/////////////////////////////////////////////////
////////////////////////////////////////////////////

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

/////////////////////////////////////////////////
// Configure the HTTP request pipeline.

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/////////////////////////////////////////////////
/////////////////////////////////////////////////
