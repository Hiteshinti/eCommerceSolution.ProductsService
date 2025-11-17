using BusinessLogicLayer;
using DataAccessLayer;
using Microsoft.Extensions.Options;
using ProductsMicroService.API.Middleware;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional:false, reloadOnChange:true)
    .AddEnvironmentVariables();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200/", "http://localhost:5423") // Change this!
                  .AllowAnyHeader()
                  .AllowAnyMethod().AllowAnyOrigin();
        });
});
builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddBusinessLogicLayer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ExceptionMiddleWare>();
app.Run();
