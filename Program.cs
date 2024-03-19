using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplication2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeesConnection")), ServiceLifetime.Scoped);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<EmployeeContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeConnection")), ServiceLifetime.Scoped);

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
