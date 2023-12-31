using FluentValidation.AspNetCore;
using TicketPurchase.Infra.Data.IoC.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddAutoMapperConfiguration();
builder.Services.AddFluentValidationConfiguration();
builder.Services.AddFluentValidationAutoValidation();
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

app.MapControllers();

app.Run();
