using ApiSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// mysql://root:tPQuJeRIkGPqdwATFYhunIKbkyonFiZW@shinkansen.proxy.rlwy.net:44516/railway = Conecxion a Railway

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
         builder =>
         {
             builder.WithOrigins("http://localhost:5173") // frontend URL
                    .AllowAnyMethod()
                    .AllowAnyHeader();
         });
});

var connectionString = builder.Configuration.GetConnectionString("Connection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
 );

builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
