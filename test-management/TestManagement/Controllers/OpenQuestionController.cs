﻿using Microsoft.AspNetCore.Mvc;
using TestManagement.CQS.Command;
using TestManagement.CQS.Command.Question;
using TestManagement.CQS.Domain.Questions;
using TestManagement.CQS.Queries;
using TestManagement.CQS.Queries.OpenQuestion;
using TestManagement.IoC;

namespace TestManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class OpenQuestionController
{
    private readonly IQueryFactory _queryFactory;
    private readonly ICommandsFactory _commandsFactory;

    public OpenQuestionController()
    {
        _queryFactory = Container.Current.Resolve<IQueryFactory>();
        _commandsFactory = Container.Current.Resolve<ICommandsFactory>();
    }

    [HttpGet]
    public List<OpenQuestion> Get()
    {
        return _queryFactory.ResolveQuery<IGetOpenQuestions>()!.Excecute().ToList();
    }

    [HttpGet("{openQuestionId}")]
    public OpenQuestion GetById(Guid openQuestionId)
    {
        return _queryFactory.ResolveQuery<IGetOpenQuestionById>()!.Excecute(openQuestionId)!;
    }


    [HttpPost]
    public void CreateOpenQuestion([FromBody] OpenQuestion openQuestion)
    {
        var createOpenQuestionCommand = new CreateQuestionCommand(openQuestion);
        _commandsFactory.ExecuteQuery(createOpenQuestionCommand);
    }


    [HttpPut]
    public void UpdateOpenQuestion([FromBody] OpenQuestion question)
    {
        var updateQuestionToTestCommand = new UpdateQuestionCommand(question);
        _commandsFactory.ExecuteQuery(updateQuestionToTestCommand);
    }
}