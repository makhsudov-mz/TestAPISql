using Microsoft.EntityFrameworkCore;

using TestAPISql;
using TestAPISql.Modules.Users.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
              options.UseMySql("server=localhost;user=root;password=;database=test_sql_db;",
            new MySqlServerVersion(new Version(8, 0, 25))).
            LogTo(s => System.Diagnostics.Debug.WriteLine(s)));

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
