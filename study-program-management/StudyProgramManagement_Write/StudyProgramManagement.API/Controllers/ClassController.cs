using System;
using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Commands.Commands.Class;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Commands.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassController : ControllerBase
{
    private readonly ICommandsFactory _commandsFactory;

    public ClassController(ICommandsFactory commandsFactory)
    {
        _commandsFactory = commandsFactory;
    }

    [HttpPost]
    public void Create([FromBody] Class model)
    {
        var command = new CreateClassCommand(model);
        _commandsFactory.ExecuteQuery(command);
    }

    [HttpPut]
    public void Update([FromBody] Class model)
    {
        var command = new UpdateClassCommand(model);
        _commandsFactory.ExecuteQuery(command);
    }

    [HttpDelete("{classId}")]
    public void Delete([FromBody] Guid modelId)
    {
        var command = new RemoveClassCommand(modelId);
        _commandsFactory.ExecuteQuery(command);
    }
}