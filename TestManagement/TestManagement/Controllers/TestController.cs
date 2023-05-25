using CQS.Command;
using CQS.Command.Test;
using CQS.Domain;
using CQS.Queries;
using CQS.Queries.Test;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using TestManagement.IoC;

namespace TestManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController
{
    private readonly ILogger<TestController> _logger;
    private readonly TestManagementDbContext _dbContext;
    private readonly IQueryFactory _queryFactory;
    private readonly ICommandsFactory _commandsFactory;

    public TestController(ILogger<TestController> logger, TestManagementDbContext dbContext)
    {
        _dbContext = dbContext;
        _logger = logger;
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