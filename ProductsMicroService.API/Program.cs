using BusinessLogicLayer;
using DataAccessLayer;
using Microsoft.Extensions.Options;
using ProductsMicroService.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200/") // Change this!
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
