using Microsoft.AspNetCore.Mvc;
using TestManagement.CQS.Command;
using TestManagement.CQS.Command.Student;
using TestManagement.CQS.Domain;
using TestManagement.CQS.Queries;
using TestManagement.CQS.Queries.StudentTest;

namespace TestManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentTestController : ControllerBase
{
    private readonly IQueryFactory _queryFactory;
    private readonly ICommandsFactory _commandsFactory;

    public StudentTestController(IQueryFactory queryFactory, ICommandsFactory commandsFactory)
    {
        _queryFactory = queryFactory;
        _commandsFactory = commandsFactory;
    }

    [HttpGet]
    public List<StudentsTests> Get()
    {
        return _queryFactory.ResolveQuery<IGetStudentTests>()!.Excecute().ToList();
    }

    [HttpGet("{studentTestId}")]
    public StudentsTests GetById(Guid studentTestId)
    {
        return _queryFactory.ResolveQuery<IGetStudentTestsById>()!.Excecute(studentTestId)!;
    }

    [HttpGet("{studentId}")]
    public IEnumerable<Test> GetByStudentId(Guid studentId)
    {
        return _queryFactory.ResolveQuery<IGetTestsByStudentId>()!.Excecute(studentId)!;
    }

    [HttpGet("{testId}")]
    public IEnumerable<Student> GetByTestId(Guid testId)
    {
        return _queryFactory.ResolveQuery<IGetStudentsByTestId>()!.Excecute(testId)!;
    }

    [HttpGet("Graded")]
    public IEnumerable<StudentsTests> GetAllGradedTests()
    {
        return _queryFactory.ResolveQuery<IGetAllGradedTests>()!.Excecute();
    }

    [HttpPut]
    public void UpdateStudentTest(StudentsTests studentTest)
    {
        var addTestToStudentCommand = new UpdateStudentTestCommand(studentTest);
        _commandsFactory.ExecuteQuery(addTestToStudentCommand);
    }

    [HttpPost]
    public void CreateStudentTest(StudentsTests studentTest)
    {
        var addTestToStudentCommand = new AddTestToStudentCommand(studentTest.TestId, studentTest.StudentId);
        _commandsFactory.ExecuteQuery(addTestToStudentCommand);
    }

    [HttpDelete]
    public void RemoveStudentFromTest(StudentsTests studentTest)
    {
        var removeStudentFromCommand = new RemoveStudentFromTestCommand(studentTest.TestId, studentTest.StudentId);
        _commandsFactory.ExecuteQuery(removeStudentFromCommand);
    }
}