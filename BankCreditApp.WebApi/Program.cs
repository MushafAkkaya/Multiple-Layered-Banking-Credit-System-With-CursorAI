using BankCreditApp.Core.CrossCuttingConcerns.Exceptions.Extensions;
using BankCreditApp.Application;
using BankCreditApp.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register Application Layer Services
builder.Services.AddApplicationServices();

// Register Persistence Layer Services
builder.Services.AddPersistenceServices(builder.Configuration.GetConnectionString("DefaultConnection"));

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
app.ConfigureCustomExceptionMiddleware();
app.MapControllers();

app.Run();