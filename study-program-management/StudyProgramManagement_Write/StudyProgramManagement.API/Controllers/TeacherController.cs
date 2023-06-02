using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Commands.Commands.Teacher;
using StudyProgramManagement.Commands.RabbitMq;
using StudyProgramManagement.Commands.RabbitMq.Clients;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Commands.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ICommandsFactory _commandsFactory;
    private readonly RabbitMqSenderClient _senderClient;

    public TeacherController(ICommandsFactory commandsFactory)
    {
        _commandsFactory = commandsFactory;
        _senderClient = new RabbitMqSenderClient(new List<string>
            { "TEST_QUEUE", "LEARNING_RESOURCES_QUEUE", "GUIDANCE_QUEUE" });
    }

    [HttpPost]
    public void Create([FromBody] Teacher model)
    {
        var command = new CreateTeacherCommand(model);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("TeacherCreated", model));
    }

    [HttpPut]
    public void Update([FromBody] Teacher model)
    {
        var command = new UpdateTeacherCommand(model);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("TeacherUpdated", model));
    }

    [HttpDelete("{teacherId}")]
    public void Delete([FromBody] Guid modelId)
    {
        var command = new RemoveTeacherCommand(modelId);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("TeacherDeleted", modelId));
    }
}