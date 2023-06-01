using System;
using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Commands.Commands.Teacher;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Commands.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ICommandsFactory _commandsFactory;

    public TeacherController(ICommandsFactory commandsFactory)
    {
        _commandsFactory = commandsFactory;
    }

    [HttpPost]
    public void Create([FromBody] Teacher model)
    {
        var command = new CreateTeacherCommand(model);
        _commandsFactory.ExecuteQuery(command);
    }

    [HttpPut]
    public void Update([FromBody] Teacher model)
    {
        var command = new UpdateTeacherCommand(model);
        _commandsFactory.ExecuteQuery(command);
    }

    [HttpDelete("{teacherId}")]
    public void Delete([FromBody] Guid modelId)
    {
        var command = new RemoveTeacherCommand(modelId);
        _commandsFactory.ExecuteQuery(command);
    }
}