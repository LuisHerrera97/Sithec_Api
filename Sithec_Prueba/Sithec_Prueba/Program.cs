using System.Net;
using Sithec_Prueba.Data;
using Microsoft.EntityFrameworkCore;
using Sithec_Prueba.Bussines.Interfaces;
using Sithec_Prueba.Bussines;
using Sithec_Prueba.Data.Interfaces;
using Sithec_Prueba.Data.Querys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string CONNECTION_STRING = builder.Configuration.GetConnectionString("puto");
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(CONNECTION_STRING);
});

builder.Services.AddScoped<IBusOperaciones, BusOperaciones>();
builder.Services.AddScoped<IBusHumano, BusHumano>();
builder.Services.AddScoped<IDatHumano, DatHumanos>();

// Cors
builder.Services.AddCors(options => options.AddPolicy("AllowWebapp",
                                    builder => builder.AllowAnyOrigin()
                                                    .AllowAnyHeader()
                                                    .AllowAnyMethod()));

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
