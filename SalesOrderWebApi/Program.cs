using Extension.CustomMiddleware;
using Microsoft.EntityFrameworkCore;
using SalesOrderWebApi.Context;
using SalesOrderWebApi.Utilities.Extension.CustomMiddleware;
using System.Text.Json.Serialization;
using Utilities.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}, ServiceLifetime.Scoped);

builder.Services.AddDbContext<QueryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}, ServiceLifetime.Scoped);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.RegisterServices();

builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ValidateModelStateFilter));
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;

});

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

app.ConfigureCustomExceptionMiddleware();

app.MapControllers();

app.Run();
