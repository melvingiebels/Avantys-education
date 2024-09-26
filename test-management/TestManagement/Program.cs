using Microsoft.EntityFrameworkCore;
using TestManagement.Infrastructure.Context;
using TestManagement.CQS.Command;
using TestManagement.CQS.Command.Question;
using TestManagement.CQS.Command.Student;
using TestManagement.CQS.Command.Test;
using TestManagement.CQS.Queries;
using TestManagement.CQS.Queries.McQuestion;
using TestManagement.CQS.Queries.OpenQuestion;
using TestManagement.CQS.Queries.Question;
using TestManagement.CQS.Queries.Student;
using TestManagement.CQS.Queries.StudentTest;
using TestManagement.CQS.Queries.Test;
using TestManagement.Infrastructure.CommandHandlers.Question;
using TestManagement.Infrastructure.CommandHandlers.Student;
using TestManagement.Infrastructure.CommandHandlers.Test;
using TestManagement.Infrastructure.QueriesHandlers.McQuestion;
using TestManagement.Infrastructure.QueriesHandlers.OpenQuestion;
using TestManagement.Infrastructure.QueriesHandlers.Question;
using TestManagement.Infrastructure.QueriesHandlers.Student;
using TestManagement.Infrastructure.QueriesHandlers.StudentTests;
using TestManagement.Infrastructure.QueriesHandlers.Test;
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

// Queries
builder.Services.AddTransient<IGetMcQuestionById, GetMcQuestionById>();
builder.Services.AddTransient<IGetMcQuestions, GetMcQuestions>();
builder.Services.AddTransient<IGetOpenQuestionById, GetOpenQuestionById>();
builder.Services.AddTransient<IGetOpenQuestions, GetOpenQuestions>();
builder.Services.AddTransient<IGetAllQuestionsFromTest, GetAllQuestionsFromTest>();
builder.Services.AddTransient<IGetQuestionById, GetQuestionById>();
builder.Services.AddTransient<IGetQuestions, GetQuestions>();
builder.Services.AddTransient<IGetStudentById, GetStudentById>();
builder.Services.AddTransient<IGetStudents, GetStudents>();
builder.Services.AddTransient<IGetAllGradedTests, GetAllGradedTests>();
builder.Services.AddTransient<IGetAllTests, GetAllTests>();
builder.Services.AddTransient<IGetTestById, GetTestById>();

// Commands
builder.Services.AddTransient<ICommandHandler<AddQuestionToTestCommand>, AddQuestionToTestCommandHandler>();
builder.Services.AddTransient<ICommandHandler<CreateQuestionCommand>, CreateQuestionCommandHandler>();
builder.Services.AddTransient<ICommandHandler<RemoveQuestionFromTestCommand>, RemoveQuestionFromTestCommandHandler>();
builder.Services.AddTransient<ICommandHandler<UpdateQuestionCommand>, UpdateQuestionCommandHandler>();
builder.Services.AddTransient<ICommandHandler<AddTestToStudentCommand>, AddTestToStudentCommandHandler>();
builder.Services.AddTransient<ICommandHandler<CreateStudentCommand>, CreateStudentCommandHandler>();
builder.Services.AddTransient<ICommandHandler<CreateTestCommand>, CreateTestCommandHandler>();
builder.Services.AddTransient<ICommandHandler<DeleteTestCommand>, DeleteTestCommandHandler>();
builder.Services.AddTransient<ICommandHandler<ReviewTestCommand>, ReviewTestCommandHandler>();

// Infrastructure
builder.Services.AddTransient<IQueryFactory>(t => new QueryFactory(t.GetRequiredService));
builder.Services.AddTransient<ICommandsFactory, CommandFactory>();

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

// RabbitMq Stuff
var rabbitMqListener = new RabbitMqListenerClient(builder.Configuration);
rabbitMqListener.Listen();