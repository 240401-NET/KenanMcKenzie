using Microsoft.EntityFrameworkCore;
using typeTestWeb.Interface;
using typeTestWeb.Models;
using typeTestWeb.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FreeDBContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<ILeaderboardRepository, LeaderboardRepository>();
builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();
builder.Services.AddSwaggerGen();

builder.Services.AddCors((options) =>
{
    options.AddPolicy("mycorspolicy", builder =>
    {
        builder.WithOrigins("*")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("mycorspolicy");
app.MapControllers();



app.Run();

