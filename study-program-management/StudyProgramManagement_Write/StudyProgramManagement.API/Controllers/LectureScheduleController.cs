using System;
using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Commands.Commands.LectureSchedule;
using StudyProgramManagement.Commands.RabbitMq;
using StudyProgramManagement.Commands.RabbitMq.Clients;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Commands.Controllers;

[ApiController]
[Route("[controller]")]
public class LectureScheduleController : ControllerBase
{
    private readonly ICommandsFactory _commandsFactory;
    private readonly RabbitMqSenderClient _senderClient;
    public LectureScheduleController(ICommandsFactory commandsFactory)
    {
        _commandsFactory = commandsFactory;
        _senderClient = new RabbitMqSenderClient(new List<string>());
    }

    [HttpPost]
    public void Create([FromBody] LecturesSchedule model)
    {
        var command = new CreateLectureScheduleCommand(model);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("LectureScheduledCreated", model));
    }

    [HttpPut]
    public void Update([FromBody] LecturesSchedule model)
    {
        var command = new UpdateLectureScheduleCommand(model);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("LectureScheduledUpdated", model));
    }

    [HttpDelete("{lectureScheduleId}")]
    public void Delete([FromBody] Guid modelId)
    {
        var command = new RemoveLectureScheduleCommand(modelId);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("LectureScheduledDeleted", modelId));
    }
}

public class LectureSchedule
{
}