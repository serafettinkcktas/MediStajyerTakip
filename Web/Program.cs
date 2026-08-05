using Application.Common.Helpers;
using Application.UseCases.Admin;
using Application.Validation.Mentor;
using Domain.Interfaces;
using FluentValidation.AspNetCore;
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
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<AccountHelper, AccountHelper>();
builder.Services.AddScoped<MentorHelper, MentorHelper>();
builder.Services.AddScoped<UserProfileHelper, UserProfileHelper>();


builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<AddMentorValidator>());
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