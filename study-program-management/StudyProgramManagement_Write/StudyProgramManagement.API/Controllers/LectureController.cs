using System;
using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Commands.Commands.Lecture;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Commands.Controllers;

[ApiController]
[Route("[controller]")]
public class LectureController : ControllerBase
{
    private readonly ICommandsFactory _commandsFactory;

    public LectureController(ICommandsFactory commandsFactory)
    {
        _commandsFactory = commandsFactory;
    }

    [HttpPost]
    public void Create([FromBody] Lecture model)
    {
        var command = new CreateLectureCommand(model);
        _commandsFactory.ExecuteQuery(command);
    }

    [HttpPut]
    public void Update([FromBody] Lecture model)
    {
        var command = new UpdateLectureCommand(model);
        _commandsFactory.ExecuteQuery(command);
    }

    [HttpDelete("{lectureId}")]
    public void Delete([FromBody] Guid modelId)
    {
        var command = new RemoveLectureCommand(modelId);
        _commandsFactory.ExecuteQuery(command);
    }
}