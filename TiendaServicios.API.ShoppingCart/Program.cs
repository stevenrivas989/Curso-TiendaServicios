using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TiendaServicios.API.ShoppingCart.Application.Business;
using TiendaServicios.API.ShoppingCart.Application.Persistence;
using TiendaServicios.API.ShoppingCart.Application.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IMaterialLibraryService, MaterialLibraryService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDesignTimeServices, MysqlEntityFrameworkDesignTimeServices>();
builder.Services.AddDbContext<ContextShoppingCart>(opt =>
{
    opt.UseMySQL(builder.Configuration.GetConnectionString("ConnectionDatabase"));
});
builder.Services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(New.Handler).Assembly);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddHttpClient("Books", config => {
    config.BaseAddress = new Uri(builder.Configuration["Services:books"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();