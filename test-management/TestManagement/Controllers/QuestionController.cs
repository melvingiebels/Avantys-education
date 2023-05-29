using Microsoft.AspNetCore.Mvc;
using TestManagement.CQS.Command;
using TestManagement.CQS.Command.Question;
using TestManagement.CQS.Domain.Questions;
using TestManagement.CQS.Queries;
using TestManagement.CQS.Queries.OpenQuestion;
using TestManagement.CQS.Queries.Question;
using TestManagement.IoC;

namespace TestManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class QuestionController
{
    private readonly IQueryFactory _queryFactory;
    private readonly ICommandsFactory _commandsFactory;


    public QuestionController()
    {
        _queryFactory = Container.Current.Resolve<IQueryFactory>();
        _commandsFactory = Container.Current.Resolve<ICommandsFactory>();
    }

    [HttpGet]
    public List<Question> Get()
    {
        return _queryFactory.ResolveQuery<IGetQuestions>()!.Excecute().ToList();
    }

    [HttpGet("{questionId}")]
    public Question GetById(Guid openQuestionId)
    {
        return _queryFactory.ResolveQuery<IGetQuestionById>()!.Excecute(openQuestionId)!;
    }


    [HttpPost]
    public void CreateQuestion([FromBody] Question question)
    {
        var createOpenQuestionCommand = new CreateQuestionCommand(question);
        _commandsFactory.ExecuteQuery(createOpenQuestionCommand);
    }

    [HttpPut("AddQuestionToTest")]
    public void AddQuestionToTest([FromBody] Guid questionId, Guid testId)
    {
        var addQuestionToTestCommand = new AddQuestionToTestCommand(questionId, testId);
        _commandsFactory.ExecuteQuery(addQuestionToTestCommand);
    }

    [HttpPut("RemoveQuestionFromTest")]
    public void RemoveQuestionFromTest([FromBody] Guid questionId, Guid testId)
    {
        var removeQuestionToTestCommand = new RemoveQuestionFromTestCommand(questionId, testId);
        _commandsFactory.ExecuteQuery(removeQuestionToTestCommand);
    }
}