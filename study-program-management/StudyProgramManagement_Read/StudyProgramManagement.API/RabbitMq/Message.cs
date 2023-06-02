namespace StudyProgramManagement.Read.RabbitMq;

public class Message
{
    public string Pattern { get; set; }
    public object Data { get; set; }

    public Message(string pattern, object data)
    {
        Pattern = pattern;
        Data = data;
    }
}