using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Commands.Commands.StudyProgram;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Commands.Controllers;

[ApiController]
[Route("[controller]")]
public class StudyProgramController: ControllerBase
{
    private readonly ICommandsFactory _commandsFactory;

    public StudyProgramController(ICommandsFactory commandsFactory)
    {
        _commandsFactory = commandsFactory;
    }
    [HttpPost]
    public void Create([FromBody] StudyProgram model)
    {
        var command = new CreateStudyProgramCommand(model);
        _commandsFactory.ExecuteQuery(command);
    }
    [HttpPut]
    public void Update([FromBody] StudyProgram model)
    {
        var command = new UpdateStudyProgramCommand(model);
        _commandsFactory.ExecuteQuery(command);
    }
    
    [HttpDelete("{studyProgramId}")]
    public void Delete([FromBody] Guid modelId)
    {
        var command = new RemoveStudyProgramCommand(modelId);
        _commandsFactory.ExecuteQuery(command);
    }
}