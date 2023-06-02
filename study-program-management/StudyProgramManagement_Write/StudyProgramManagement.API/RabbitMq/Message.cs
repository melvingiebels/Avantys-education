using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Commands.RabbitMq;

public class Message
{
    public Message(string pattern, Model data)
    {
        Pattern = pattern;
        Data = data;
    }

    public Message(string pattern, Guid modelId)
    {
        Pattern = pattern;
        Data = modelId;
    }

    public string Pattern { get; set; }
    public object Data { get; set; }
}