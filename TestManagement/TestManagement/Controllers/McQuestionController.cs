﻿using Microsoft.AspNetCore.Mvc;
using TestManagement.CQS.Command;
using TestManagement.CQS.Command.Question;
using TestManagement.CQS.Domain.Questions;
using TestManagement.CQS.Queries;
using TestManagement.CQS.Queries.McQuestion;
using TestManagement.CQS.Queries.Question;
using TestManagement.IoC;

namespace TestManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class McQuestionController
{
    private readonly IQueryFactory _queryFactory;
    private readonly ICommandsFactory _commandsFactory;

    public McQuestionController()
    {
        _queryFactory = Container.Current.Resolve<IQueryFactory>();
        _commandsFactory = Container.Current.Resolve<ICommandsFactory>();
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
    public void UpdateQuestion([FromBody]McQuestion question)
    {
        var updateQuestionToTestCommand = new UpdateQuestionCommand(question);
        _commandsFactory.ExecuteQuery(updateQuestionToTestCommand);
    }
}