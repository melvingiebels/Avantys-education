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

    [HttpPut]
    public void UpdateStudent(Student student)
    {
        var addTestToStudentCommand = new UpdateStudentCommand(student);
        _commandsFactory.ExecuteQuery(addTestToStudentCommand);
    }

    [HttpPost]
    public void CreateStudent([FromBody] Student student)
    {
        var createStudentCommand = new CreateStudentCommand(student);
        _commandsFactory.ExecuteQuery(createStudentCommand);
    }

    [HttpDelete("{studentId}")]
    public void DeleteQuestion([FromRoute] Guid studentId)
    {
        var studentToBeDeleted = _queryFactory.ResolveQuery<IGetStudentById>()!.Excecute(studentId)!;
        var updateQuestionToTestCommand = new DeleteStudentCommand(studentToBeDeleted);
        _commandsFactory.ExecuteQuery(updateQuestionToTestCommand);
    }
}