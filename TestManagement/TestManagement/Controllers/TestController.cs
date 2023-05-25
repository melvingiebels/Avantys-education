using TestManagement.CQS.Command;
using TestManagement.CQS.Command.Test;
using TestManagement.CQS.Domain;
using TestManagement.CQS.Queries;
using TestManagement.CQS.Queries.Test;
using TestManagement.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using TestManagement.IoC;

namespace TestManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController
{
    private readonly IQueryFactory _queryFactory;
    private readonly ICommandsFactory _commandsFactory;

    public TestController()
    {
        _queryFactory = Container.Current.Resolve<IQueryFactory>();
        _commandsFactory = Container.Current.Resolve<ICommandsFactory>();
    }

    [HttpGet]
    public IEnumerable<Test> Get()
    {
        return _queryFactory.ResolveQuery<IGetAllTests>()!.Excecute();
    }

    [HttpGet("{testId}")]
    public Test GetById(Guid testId)
    {
        return _queryFactory.ResolveQuery<IGetTestById>()!.Excecute(testId);
    }

    [HttpGet("graded")]
    public IEnumerable<Test> GetAllGradedTests()
    {
        return _queryFactory.ResolveQuery<IGetAllGradedTests>()!.Excecute();
    }

    [HttpPost]
    public void CreateTest([FromBody] Test test)
    {
        var createTestCommand = new CreateTestCommand(test);
        _commandsFactory.ExecuteQuery(createTestCommand);
    }

    [HttpDelete]
    public void DeleteTest([FromBody] Test test)
    {
        var deleteTestCommand = new DeleteTestCommand(test);
        _commandsFactory.ExecuteQuery(deleteTestCommand);
    }

    [HttpPut]
    public void ReviewTest([FromBody] Guid testId, Guid studentId, double score)
    {
        var reviewTestCommand = new ReviewTestCommand(testId, studentId, score);
        _commandsFactory.ExecuteQuery(reviewTestCommand);
    }
}