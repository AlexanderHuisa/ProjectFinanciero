using APIRestPersonasNaturales.Infraestructura.EntityFrameworkContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MicrofinanzaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBMicrofinanza"));
    //builder.Environment.IsDevelopment() ?
    //    options.UseSqlServer(builder.Configuration.GetConnectionString("DbDesarrollo23")) :
    //    options.UseSqlServer("Hola")// string.Format("Server={0}; Database={1}; User={2}; Password={3}; Encrypt=false; TrustServerCertificate=True; MultiSubnetFailover=False", "DB_SERVER", "DB_NAME", "DB_USER", "DB_PASSWORD"));
});

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
