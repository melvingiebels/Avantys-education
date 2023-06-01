using System;
using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Commands.Commands.Lecture;
using StudyProgramManagement.Commands.RabbitMq;
using StudyProgramManagement.Commands.RabbitMq.Clients;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Commands.Controllers;

[ApiController]
[Route("[controller]")]
public class LectureController : ControllerBase
{
    private readonly ICommandsFactory _commandsFactory;
    private readonly RabbitMqSenderClient _senderClient;
    public LectureController(ICommandsFactory commandsFactory)
    {
        _commandsFactory = commandsFactory;
        _senderClient = new RabbitMqSenderClient(new List<string>());
    }

    [HttpPost]
    public void Create([FromBody] Lecture model)
    {
        var command = new CreateLectureCommand(model);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("LectureCreated", model));
    }

    [HttpPut]
    public void Update([FromBody] Lecture model)
    {
        var command = new UpdateLectureCommand(model);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("LectureUpdated", model));
    }

    [HttpDelete("{lectureId}")]
    public void Delete([FromBody] Guid modelId)
    {
        var command = new RemoveLectureCommand(modelId);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("LectureDeleted", modelId));
    }
}