using Microsoft.EntityFrameworkCore;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Repos;
using StudyProgramManagement.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Repositories for DI
builder.Services.AddScoped<IRepository<Class>, ClassRepository>();
builder.Services.AddScoped<IRepository<Lecture>, LectureRepository>();
builder.Services.AddScoped<IRepository<LecturesSchedule>, LectureScheduleRepository>();
builder.Services.AddScoped<IRepository<Module>, ModuleRepository>();
builder.Services.AddScoped<IRepository<Student>, StudentRepository>();
builder.Services.AddScoped<IRepository<StudyProgram>, StudyProgramRepository>();
builder.Services.AddScoped<IRepository<Teacher>, TeacherRepository>();
builder.Services.AddScoped<IRepository<TeacherModules>, TeacherModulesRepository>();

// DbContext
builder.Services.AddDbContext<StudyProgramManagementDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("SQL");
    options.UseSqlServer(connectionString,
        b => b.MigrationsAssembly("StudyProgramManagement"));
});

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