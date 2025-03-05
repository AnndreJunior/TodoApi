using TodoApi.Application;
using TodoApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var allowedHosts = builder.Configuration["AllowedHosts"]!;

// Add services to the container.
builder
    .AddDbContext()
    .AddRepositories()
    .UseApplication();

builder.Services.AddCors(opts =>
{
    opts.AddDefaultPolicy(policy => policy
        .WithOrigins(allowedHosts)
        .AllowAnyHeader()
        .AllowAnyMethod());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
