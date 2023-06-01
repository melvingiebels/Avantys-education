using System;
using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Commands.Commands.LectureSchedule;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Commands.Controllers;

[ApiController]
[Route("[controller]")]
public class LectureScheduleController : ControllerBase
{
    private readonly ICommandsFactory _commandsFactory;

    public LectureScheduleController(ICommandsFactory commandsFactory)
    {
        _commandsFactory = commandsFactory;
    }

    [HttpPost]
    public void Create([FromBody] LecturesSchedule model)
    {
        var command = new CreateLectureScheduleCommand(model);
        _commandsFactory.ExecuteQuery(command);
    }

    [HttpPut]
    public void Update([FromBody] LecturesSchedule model)
    {
        var command = new UpdateLectureScheduleCommand(model);
        _commandsFactory.ExecuteQuery(command);
    }

    [HttpDelete("{lectureScheduleId}")]
    public void Delete([FromBody] Guid modelId)
    {
        var command = new RemoveLectureScheduleCommand(modelId);
        _commandsFactory.ExecuteQuery(command);
    }
}

public class LectureSchedule
{
}