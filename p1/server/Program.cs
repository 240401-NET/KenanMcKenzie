using server.Model;
using server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddAuthorization();
var connectionString = builder.Configuration["connectionstring"];
Console.WriteLine("connstring: " + connectionString);
builder.Services.AddDbContext<FreeDbContext>(x => x.UseSqlServer(connectionString));
//make services and add them to builder
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<FreeDbContext>();
builder.Services.AddIdentityCore<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;

    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;

    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<FreeDbContext>();

//connectionstring
//if Repository or service is calling dbContext -> builder.Services.AddScoped<QuizRepository>()


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
//select the interface that has just the required method, not the one with extra
//efcore migration, choose the one with the dash
app.MapIdentityApi<User>();

app.MapControllers();
app.Run();


//dotnet user-secrets init -> in 
//dotnet user-secrets set "dbconnectionString" "connection string in quotes