using System;
using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Commands.Commands.Student;
using StudyProgramManagement.Commands.RabbitMq;
using StudyProgramManagement.Commands.RabbitMq.Clients;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Commands.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly ICommandsFactory _commandsFactory;
    private readonly RabbitMqSenderClient _senderClient;
    public StudentController(ICommandsFactory commandsFactory)
    {
        _commandsFactory = commandsFactory;
        _senderClient = new RabbitMqSenderClient(new List<string>());
    }

    [HttpPost]
    public void Create([FromBody] Student model)
    {
        var command = new CreateStudentCommand(model);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("StudentCreated", model));
    }

    [HttpPut]
    public void Update([FromBody] Student model)
    {
        var command = new UpdateStudentCommand(model);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("StudentUpdated", model));

    }

    [HttpDelete("{studentId}")]
    public void Delete([FromBody] Guid modelId)
    {
        var command = new RemoveStudentCommand(modelId);
        _commandsFactory.ExecuteQuery(command);
        _senderClient.SendMessage(new Message("StudentDeleted", modelId));
    }
}