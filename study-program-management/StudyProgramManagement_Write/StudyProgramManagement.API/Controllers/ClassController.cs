using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Commands.Commands.Class;
using StudyProgramManagement.Commands.RabbitMq;
using StudyProgramManagement.Commands.RabbitMq.Clients;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Commands.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassController : ControllerBase
{
    private readonly ICommandsFactory _commandsFactory;
    private readonly RabbitMqSenderClient _senderClient;

    public ClassController(ICommandsFactory commandsFactory)
    {
        _commandsFactory = commandsFactory;
        _senderClient = new RabbitMqSenderClient(new List<string>());
    }

    [HttpPost]
    public void Create([FromBody] Class model)
    {
        var command = new CreateClassCommand(model);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("ClassCreated", model));
    }

    [HttpPut]
    public void Update([FromBody] Class model)
    {
        var command = new UpdateClassCommand(model);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("ClassUpdated", model));
    }

    [HttpDelete("{classId}")]
    public void Delete([FromBody] Guid modelId)
    {
        var command = new RemoveClassCommand(modelId);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("ClassDeleted", modelId));
    }
}