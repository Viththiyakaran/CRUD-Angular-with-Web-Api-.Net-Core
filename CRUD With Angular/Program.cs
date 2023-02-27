using CRUD_With_Angular.Database;
using CRUD_With_Angular.Interface;
using CRUD_With_Angular.Repo;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmployee, EmployeeService>();

builder.Services.AddDbContext<AppDbContext>( options => options.UseSqlServer(builder.Configuration.GetConnectionString("ServerCon")));

builder.Services.AddCors((CorsOptions) =>
{
    CorsOptions.AddPolicy("MyPolicy", (corsOpt) => {

        corsOpt.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("MyPolicy");

app.MapControllers();

app.Run();
