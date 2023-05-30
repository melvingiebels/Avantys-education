using System.Text.Json.Serialization;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Domain.Schemas;

public class LectureSchema
{
    public Guid Id { get; set; }
    public string Topic { get; set; }
    public Module Module { get; set; }

    public LectureSchema(string topic, Module module)
    {
        Id = new Guid();
        Topic = topic;
        Module = module;
    }

    public LectureSchema()
    {
    }
}