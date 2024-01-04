using FluentValidation.AspNetCore;
using System.Reflection;
using TicketPurchase.Api.Middleware;
using TicketPurchase.Infra.Data.IoC.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddAutoMapperConfiguration();
builder.Services.AddFluentValidationConfiguration();
builder.Services.AddFluentValidationAutoValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(op =>
{


    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
    op.IncludeXmlComments(xmlPath);
    xmlPath = Path.Combine(AppContext.BaseDirectory, "TicketPurchase.Application.xml");
    op.IncludeXmlComments(xmlPath);

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

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
