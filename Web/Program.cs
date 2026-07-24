using Application.UseCases.Admin;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<IDbConnectionFactory, SqlConnectionHandler>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<AddMentorUseCase>();
builder.Services.AddTransient<CreateRoleUseCase>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
var app = builder.Build();
// TODO : siteyi cikarirken duzenlenecek 
 
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAll");
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();