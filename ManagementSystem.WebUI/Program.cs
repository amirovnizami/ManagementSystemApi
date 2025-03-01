using ManagementSystem.Application;
using ManagementSystem.DAL.SqlServer;
using ManagmentSystem.WebUI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("MyCon");
builder.Services.AddSqlServerServices(connectionString);
builder.Services.AddApplicationServices();
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.FullName);
});
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseMiddleware<RateLimitingMiddleware>();
app.MapControllers();

app.Run();