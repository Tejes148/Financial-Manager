using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UserService.Core.Commands.RegisterUser;
using UserService.Core.FluentValidation;
using UserService.Core.Interfaces;
using UserService.Infrastructure.Persistence;
using UserService.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// FluentValidation setup
builder.Services.AddValidatorsFromAssemblyContaining<RegisterUserCommandValidator>();

// DbContext
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped<IUserRepository, UserRepository>();

// MediatR setup
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommandHandler).Assembly);
});

// Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();