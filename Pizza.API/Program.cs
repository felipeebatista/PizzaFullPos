//PIZZA API

using Microsoft.EntityFrameworkCore;
using Pizza.API.Percistence;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddServiceDiscovery(options => options.UseConsul());

builder.Services.AddDbContext<PizzaDbContext>(options => options.UseInMemoryDatabase("pizza"));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PizzaRepository>();
builder.Services.AddScoped<EstoqueRepository>();

builder.Services.AddProblemDetails();

builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseHealthChecks("/health");

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseExceptionHandler("/error");


app.Run();