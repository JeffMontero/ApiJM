using JMApi.Data;
using JMApi.Interfaces;
using JMApi.Middleware;
using JMApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDB")));

#region : Iyeccion de dependencias
builder.Services.AddTransient<IColegio, ColegioService>();
builder.Services.AddTransient<IUsuario, UsuarioService>();
builder.Services.AddTransient<IMateria, MateriaService>();
builder.Services.AddTransient<ICalificacion, CalificacionService>();
#endregion : Inyeccion de depencdencias 

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();

app.Run();
