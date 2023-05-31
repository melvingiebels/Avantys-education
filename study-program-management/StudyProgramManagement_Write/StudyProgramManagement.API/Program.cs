using Microsoft.EntityFrameworkCore;
using StudyProgramManagement.Commands;
using StudyProgramManagement.Commands.Commands.Class;
using StudyProgramManagement.Commands.Commands.Lecture;
using StudyProgramManagement.Commands.Commands.LectureSchedule;
using StudyProgramManagement.Commands.Commands.Module;
using StudyProgramManagement.Commands.Commands.Student;
using StudyProgramManagement.Commands.Commands.StudyProgram;
using StudyProgramManagement.Commands.Commands.Teacher;
using StudyProgramManagement.Commands.Commands.TeacherModules;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Handlers.CommandHandlers.Class;
using StudyProgramManagement.Infrastructure.Handlers.CommandHandlers.Lecture;
using StudyProgramManagement.Infrastructure.Handlers.CommandHandlers.LectureSchedule;
using StudyProgramManagement.Infrastructure.Handlers.CommandHandlers.Module;
using StudyProgramManagement.Infrastructure.Handlers.CommandHandlers.Student;
using StudyProgramManagement.Infrastructure.Handlers.CommandHandlers.StudyProgram;
using StudyProgramManagement.Infrastructure.Handlers.CommandHandlers.Teacher;
using StudyProgramManagement.Infrastructure.Handlers.CommandHandlers.TeacherModules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Commands

// Class
builder.Services.AddTransient<ICommandHandler<CreateClassCommand>, CreateClassCommandHandler>();
builder.Services.AddTransient<ICommandHandler<RemoveClassCommand>, RemoveClassCommandHandler>();
builder.Services.AddTransient<ICommandHandler<UpdateClassCommand>, UpdateClassCommandHandler>();

// Lecture
builder.Services.AddTransient<ICommandHandler<CreateLectureCommand>, CreateLectureCommandHandler>();
builder.Services.AddTransient<ICommandHandler<RemoveLectureCommand>, RemoveLectureCommandHandler>();
builder.Services.AddTransient<ICommandHandler<UpdateLectureCommand>, UpdateLectureCommandHandler>();

// Lecture Schedule
builder.Services.AddTransient<ICommandHandler<CreateLectureScheduleCommand>, CreateLectureScheduleCommandHandler>();
builder.Services.AddTransient<ICommandHandler<RemoveLectureScheduleCommand>, RemoveLectureScheduleCommandHandler>();
builder.Services.AddTransient<ICommandHandler<UpdateLectureScheduleCommand>, UpdateLectureScheduleCommandHandler>();

// Module
builder.Services.AddTransient<ICommandHandler<CreateModuleCommand>, CreateModuleCommandHandler>();
builder.Services.AddTransient<ICommandHandler<RemoveModuleCommand>, RemoveModuleCommandHandler>();
builder.Services.AddTransient<ICommandHandler<UpdateModuleCommand>, UpdateModuleCommandHandler>();

// Student
builder.Services.AddTransient<ICommandHandler<CreateStudentCommand>, CreateStudentCommandHandler>();
builder.Services.AddTransient<ICommandHandler<RemoveStudentCommand>, RemoveStudentCommandHandler>();
builder.Services.AddTransient<ICommandHandler<UpdateStudentCommand>, UpdateStudentCommandHandler>();

// Study Program
builder.Services.AddTransient<ICommandHandler<CreateStudyProgramCommand>, CreateStudyProgramCommandHandler>();
builder.Services.AddTransient<ICommandHandler<RemoveStudyProgramCommand>, RemoveStudyProgramCommandHandler>();
builder.Services.AddTransient<ICommandHandler<UpdateStudyProgramCommand>, UpdateStudyProgramCommandHandler>();

// Teacher
builder.Services.AddTransient<ICommandHandler<CreateTeacherCommand>, CreateTeacherCommandHandler>();
builder.Services.AddTransient<ICommandHandler<RemoveTeacherCommand>, RemoveTeacherCommandHandler>();
builder.Services.AddTransient<ICommandHandler<UpdateTeacherCommand>, UpdateTeacherCommandHandler>();

// Teacher Modules
builder.Services.AddTransient<ICommandHandler<CreateTeacherModulesCommand>, CreateTeacherModulesCommandHandler>();
builder.Services.AddTransient<ICommandHandler<RemoveTeacherModulesCommand>, RemoveTeacherModulesCommandHandler>();
builder.Services.AddTransient<ICommandHandler<UpdateTeacherModulesCommand>, UpdateTeacherModulesCommandHandler>();

// DbContext
builder.Services.AddDbContext<StudyProgramManagementDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("SQL");
    options.UseSqlServer(connectionString,
        b => b.MigrationsAssembly("StudyProgramManagement"));
});

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("http://localhost:3003")
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