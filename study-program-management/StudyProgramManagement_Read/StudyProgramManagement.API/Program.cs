using StudyProgramManagement.Infrastructure.Handlers.Class;
using StudyProgramManagement.Infrastructure.Handlers.Lecture;
using StudyProgramManagement.Infrastructure.Handlers.LectureSchedule;
using StudyProgramManagement.Infrastructure.Handlers.Module;
using StudyProgramManagement.Infrastructure.Handlers.Student;
using StudyProgramManagement.Infrastructure.Handlers.StudyProgram;
using StudyProgramManagement.Infrastructure.Handlers.Teacher;
using StudyProgramManagement.Infrastructure.Handlers.TeacherModules;
using StudyProgramManagement.Infrastructure.MongoDb;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query;
using StudyProgramManagement.Query.Queries;
using StudyProgramManagement.Query.Queries.Class;
using StudyProgramManagement.Query.Queries.Lecture;
using StudyProgramManagement.Query.Queries.LecturesSchedule;
using StudyProgramManagement.Query.Queries.Module;
using StudyProgramManagement.Query.Queries.Student;
using StudyProgramManagement.Query.Queries.StudyProgram;
using StudyProgramManagement.Query.Queries.Teacher;
using StudyProgramManagement.Query.Queries.TeacherModules;
using StudyProgramManagement.Read.RabbitMq;

var builder = WebApplication.CreateBuilder(args);

var listener = new RabbitMqListenerClient(new MongoDbClient(), "STUDY_PROGRAM_READ");
listener.StartListening();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Infrastructure
builder.Services.AddTransient<IQueryFactory>(t => new QueryFactory(t.GetRequiredService));
builder.Services.AddSingleton<MongoDbClient>(_ => new MongoDbClient());

// Collections
builder.Services.AddSingleton<ClassCollection>();
builder.Services.AddSingleton<LectureCollection>();
builder.Services.AddSingleton<LectureScheduleCollection>();
builder.Services.AddSingleton<ModuleCollection>();
builder.Services.AddSingleton<StudentCollection>();
builder.Services.AddSingleton<StudyProgramCollection>();
builder.Services.AddSingleton<TeacherCollection>();
builder.Services.AddSingleton<TeacherModulesCollection>();

// Queries  
// Class
builder.Services.AddTransient<IGetAllClasses, GetAllClassesHandler>();
builder.Services.AddTransient<IGetClassById, GetClassByIdHandler>();
// Lecture
builder.Services.AddTransient<IGetAllLectures, GetAllLecturesHandler>();
builder.Services.AddTransient<IGetLectureById, GetLectureByIdHandler>();
// LectureSchedule
builder.Services.AddTransient<IGetAllLectureSchedules, GetAllLectureSchedulesHandler>();
builder.Services.AddTransient<IGetLectureScheduleById, GetLectureSchedulesByIdHandler>();
// Module
builder.Services.AddTransient<IGetAllModules, GetAllModulesHandler>();
builder.Services.AddTransient<IGetModuleById, GetModuleByIdHandler>();
// Student
builder.Services.AddTransient<IGetAllStudents, GetAllStudentsHandler>();
builder.Services.AddTransient<IGetStudentById, GetStudentByIdHandler>();
// StudyPrograms
builder.Services.AddTransient<IGetAllStudyPrograms, GetAllStudyProgramsHandler>();
builder.Services.AddTransient<IGetStudentById, GetStudentByIdHandler>();
// Teacher
builder.Services.AddTransient<IGetAllTeachers, GetAllTeachersHandler>();
builder.Services.AddTransient<IGetTeacherById, GetTeacherByIdHandler>();
// Teacher Modules
builder.Services.AddTransient<IGetAllTeacherModules, GetAllTeacherModulesHandler>();
builder.Services.AddTransient<IGetTeacherModuleById, GetTeacherModulesByIdHandler>();

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("http://localhost:44377")
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