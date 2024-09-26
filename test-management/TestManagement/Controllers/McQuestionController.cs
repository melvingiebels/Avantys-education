using Microsoft.AspNetCore.Mvc;
using TestManagement.CQS.Command;
using TestManagement.CQS.Command.Question;
using TestManagement.CQS.Domain.Questions;
using TestManagement.CQS.Queries;
using TestManagement.CQS.Queries.McQuestion;
using TestManagement.Infrastructure.CommandHandlers.Question;

namespace TestManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class McQuestionController
{
    private readonly IQueryFactory _queryFactory;
    private readonly ICommandsFactory _commandsFactory;

    public McQuestionController(IQueryFactory queryFactory, ICommandsFactory commandsFactory)
    {
        _queryFactory = queryFactory;
        _commandsFactory = commandsFactory;
    }

    [HttpGet]
    public List<McQuestion> Get()
    {
        return _queryFactory.ResolveQuery<IGetMcQuestions>()!.Excecute().ToList();
    }

    [HttpGet("{mcQuestionId}")]
    public McQuestion GetById(Guid mcQuestionId)
    {
        return _queryFactory.ResolveQuery<IGetMcQuestionById>()!.Excecute(mcQuestionId)!;
    }


    [HttpPost]
    public void CreateMcQuestion([FromBody] McQuestion mcQuestion)
    {
        var createMcQuestionCommand = new CreateQuestionCommand(mcQuestion);
        _commandsFactory.ExecuteQuery(createMcQuestionCommand);
    }

    [HttpPut]
    public void UpdateQuestion([FromBody] McQuestion question)
    {
        var updateQuestionToTestCommand = new UpdateQuestionCommand(question);
        _commandsFactory.ExecuteQuery(updateQuestionToTestCommand);
    }

    [HttpDelete("{mcQuestionId}")]
    public void DeleteQuestion([FromRoute] Guid mcQuestionId)
    {
        var questionToBeDeleted = _queryFactory.ResolveQuery<IGetMcQuestionById>()!.Excecute(mcQuestionId)!;
        var updateQuestionToTestCommand = new DeleteQuestionCommand(questionToBeDeleted);
        _commandsFactory.ExecuteQuery(updateQuestionToTestCommand);
    }
}