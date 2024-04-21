using server.Model;
using server.Data;
using Microsoft.EntityFrameworkCore;
using server.Interface;
using server.Repository;
using server.Service;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        });

builder.Services.AddAuthorization();

var connectionString = builder.Configuration["DBConnectionString:"];
Console.WriteLine("connstring: " + connectionString);
builder.Services.AddDbContext<FreeDbContext>(x => x.UseSqlServer(connectionString));
//make services and add them to builder
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<FreeDbContext>();
builder.Services.AddIdentityCore<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;

    options.User.RequireUniqueEmail = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
}).AddEntityFrameworkStores<FreeDbContext>();
builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IQuizService, QuizService>();

//connectionstring
//if Repository or service is calling dbContext -> builder.Services.AddScoped<QuizRepository>()

builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//HTTPS
app.UseHttpsRedirection();

//ROUTING
app.MapControllers();
app.MapIdentityApi<User>();

//CORS
app.UseCors("AllowAll");
//AUTHENTICATION 
//AUTHORIZATION
app.UseAuthorization();
//select the interface that has just the required method, not the one with extra
//efcore migration, choose the one with the dash


app.Run();


//dotnet user-secrets init -> in 
//dotnet user-secrets set "dbconnectionString" "connection string in quotes