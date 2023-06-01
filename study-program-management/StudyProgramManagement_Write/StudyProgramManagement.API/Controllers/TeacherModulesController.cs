using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Commands.Commands.TeacherModules;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Commands.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherModulesController : ControllerBase
{
    private readonly ICommandsFactory _commandsFactory;

    public TeacherModulesController(ICommandsFactory commandsFactory)
    {
        _commandsFactory = commandsFactory;
    }

    [HttpPost]
    public void Create([FromBody] TeacherModules model)
    {
        var command = new CreateTeacherModulesCommand(model);
        _commandsFactory.ExecuteQuery(command);
    }

    [HttpPut]
    public void Update([FromBody] TeacherModules model)
    {
        var command = new UpdateTeacherModulesCommand(model);
        _commandsFactory.ExecuteQuery(command);
    }

    [HttpDelete("{teacherId}")]
    public void Delete([FromBody] Guid modelId)
    {
        var command = new RemoveTeacherModulesCommand(modelId);
        _commandsFactory.ExecuteQuery(command);
    }
}