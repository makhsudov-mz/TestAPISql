using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using TestAPISql;
using TestAPISql.Modules.Users.Extensions;

const string connectionString = "server=10.10.2.201;user=root;password=Or!Gami99;database=test_sql_db;";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var confing =  builder.Configuration();
builder.Services.AddDbContext<AppDbContext>(options =>
              options.UseNpgsql("Host=localhost;Port=5432;Database=test_sql_db;Username=postgres;Password=0626"));

builder.Services.AddUserServiceCollections();


var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
