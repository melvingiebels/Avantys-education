using System;
using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Commands.Commands.TeacherModules;
using StudyProgramManagement.Commands.RabbitMq;
using StudyProgramManagement.Commands.RabbitMq.Clients;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Commands.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherModulesController : ControllerBase
{
    private readonly ICommandsFactory _commandsFactory;
    private readonly RabbitMqSenderClient _senderClient;
    public TeacherModulesController(ICommandsFactory commandsFactory)
    {
        _commandsFactory = commandsFactory;
        _senderClient = new RabbitMqSenderClient(new List<string>());
    }

    [HttpPost]
    public void Create([FromBody] TeacherModules model)
    {
        var command = new CreateTeacherModulesCommand(model);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("TeacherModuleCreated", model));
    }

    [HttpPut]
    public void Update([FromBody] TeacherModules model)
    {
        var command = new UpdateTeacherModulesCommand(model);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("TeacherModuleUpdated", model));
    }

    [HttpDelete("{teacherId}")]
    public void Delete([FromBody] Guid modelId)
    {
        var command = new RemoveTeacherModulesCommand(modelId);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("TeacherModuleDeleted", modelId));
    }
}