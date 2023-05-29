using Microsoft.AspNetCore.Mvc;
using TestManagement.CQS.Command;
using TestManagement.CQS.Command.Student;
using TestManagement.CQS.Domain;
using TestManagement.CQS.Queries;
using TestManagement.CQS.Queries.Student;

namespace TestManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController
{
    private readonly IQueryFactory _queryFactory;
    private readonly ICommandsFactory _commandsFactory;

    public StudentController(IQueryFactory queryFactory, ICommandsFactory commandsFactory)
    {
        _queryFactory = queryFactory;
        _commandsFactory = commandsFactory;
    }

    [HttpGet]
    public List<Student> Get()
    {
        return _queryFactory.ResolveQuery<IGetStudents>()!.Excecute().ToList();
    }

    [HttpGet("{studentId}")]
    public Student GetById(Guid studentId)
    {
        return _queryFactory.ResolveQuery<IGetStudentById>()!.Excecute(studentId)!;
    }


    [HttpPost("AddTestToStudent")]
    public void AddTestToStudentCommand([FromBody] Guid studentId, Guid testId)
    {
        var addTestToStudentCommand = new AddTestToStudentCommand(studentId, testId);
        _commandsFactory.ExecuteQuery(addTestToStudentCommand);
    }

    [HttpPost("CreateStudent")]
    public void CreateStudent([FromBody] Student student)
    {
        var createStudentCommand = new CreateStudentCommand(student);
        _commandsFactory.ExecuteQuery(createStudentCommand);
    }
}