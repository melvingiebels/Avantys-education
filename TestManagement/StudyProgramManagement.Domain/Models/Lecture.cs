namespace StudyProgramManagement.Domain.Models;

public class Lecture
{
    public Guid Id { get; set; }
    public string Topic { get; set; }
    public Module Module { get; set; }
    public DateTime DateScheduled { get; set; }

    public Lecture(string topic, Module module, DateTime dateScheduled)
    {
        Id = new Guid();
        Topic = topic;
        Module = module;
        DateScheduled = dateScheduled;
    }
}