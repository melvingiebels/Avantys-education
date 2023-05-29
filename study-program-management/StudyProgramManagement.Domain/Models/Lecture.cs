namespace StudyProgramManagement.Domain.Models;

public class Lecture
{
    public Guid Id { get; set; }
    public string Topic { get; set; }
    public Module Module { get; set; }

    public Lecture(string topic, Module module)
    {
        Id = new Guid();
        Topic = topic;
        Module = module;
    }

    public Lecture()
    {
    }
}