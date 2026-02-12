using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vestigia.Infrastructure.Data;
using Vestigia.Application.UseCases;
using Vestigia.Domain.Interfaces;
using Vestigia.Infrastructure.Repositories;
using Vestigia.Infrastructure.Security;
using static System.Net.Mime.MediaTypeNames;
using Vestigia.Application.UseCases.UsuarioUC;
using Vestigia.Application.UseCases.ContaUC;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// Controllers
builder.Services.AddControllers();

// Use Cases
builder.Services.AddScoped<UsuarioUC>();
builder.Services.AddScoped<ContaUC>();

// Repositories
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IContaRepository, ContaRepository>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {});

//DB
builder.Services.AddDbContext<VestigiaContext>(options => 
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Vestigia.Infrastructure")));

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI( c => {});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
