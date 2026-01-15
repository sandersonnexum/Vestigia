using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vestigia.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Controllers
builder.Services.AddControllers();

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
