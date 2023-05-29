using Microsoft.EntityFrameworkCore;
using TestManagement.Infrastructure.Context;
using TestManagement.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TestManagementDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("SQL");
    options.UseSqlServer(connectionString,
        b => b.MigrationsAssembly("TestManagement"));
});

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("http://localhost:3004")
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

var rabbitMqListener = new RabbitMqListenerClient(builder.Configuration);
rabbitMqListener.Listen();