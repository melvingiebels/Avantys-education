using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Commands.Commands.Module;
using StudyProgramManagement.Commands.RabbitMq;
using StudyProgramManagement.Commands.RabbitMq.Clients;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Commands.Controllers;

[ApiController]
[Route("[controller]")]
public class ModuleController : ControllerBase
{
    private readonly ICommandsFactory _commandsFactory;
    private readonly RabbitMqSenderClient _senderClient;

    public ModuleController(ICommandsFactory commandsFactory)
    {
        _commandsFactory = commandsFactory;
        _senderClient = new RabbitMqSenderClient(new List<string> { "TEST_QUEUE", "LEARNING_RESOURCES_QUEUE" });
    }

    [HttpPost]
    public void Create([FromBody] Module model)
    {
        var command = new CreateModuleCommand(model);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("ModuleCreated", model));
    }

    [HttpPut]
    public void Update([FromBody] Module model)
    {
        var command = new UpdateModuleCommand(model);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("ModuleUpdated", model));
    }

    [HttpDelete("{moduleId}")]
    public void Delete([FromBody] Guid modelId)
    {
        var command = new RemoveModuleCommand(modelId);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("ModuleDeleted", modelId));
    }
}