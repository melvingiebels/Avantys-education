using System;
using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Commands.Commands.Student;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Commands.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly ICommandsFactory _commandsFactory;

    public StudentController(ICommandsFactory commandsFactory)
    {
        _commandsFactory = commandsFactory;
    }

    [HttpPost]
    public void Create([FromBody] Student model)
    {
        var command = new CreateStudentCommand(model);
        _commandsFactory.ExecuteQuery(command);
    }

    [HttpPut]
    public void Update([FromBody] Student model)
    {
        var command = new UpdateStudentCommand(model);
        _commandsFactory.ExecuteQuery(command);
    }

    [HttpDelete("{studentId}")]
    public void Delete([FromBody] Guid modelId)
    {
        var command = new RemoveStudentCommand(modelId);
        _commandsFactory.ExecuteQuery(command);
    }
}