using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Commands.Commands.StudyProgram;
using StudyProgramManagement.Commands.RabbitMq;
using StudyProgramManagement.Commands.RabbitMq.Clients;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Commands.Controllers;

[ApiController]
[Route("[controller]")]
public class StudyProgramController : ControllerBase
{
    private readonly ICommandsFactory _commandsFactory;
    private readonly RabbitMqSenderClient _senderClient;

    public StudyProgramController(ICommandsFactory commandsFactory)
    {
        _commandsFactory = commandsFactory;
        _senderClient = new RabbitMqSenderClient(new List<string> { "REGISTRATION_QUEUE", "LEARNING_RESOURCES_QUEUE" });
    }

    [HttpPost]
    public void Create([FromBody] StudyProgram model)
    {
        var command = new CreateStudyProgramCommand(model);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("StudyProgramCreated", model));
    }

    [HttpPut]
    public void Update([FromBody] StudyProgram model)
    {
        var command = new UpdateStudyProgramCommand(model);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("StudyProgramUpdated", model));
    }

    [HttpDelete("{studyProgramId}")]
    public void Delete([FromBody] Guid modelId)
    {
        var command = new RemoveStudyProgramCommand(modelId);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("StudyProgramDeleted", modelId));
    }
}