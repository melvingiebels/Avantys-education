using System;

namespace StudyProgramManagement.Domain.Schemas;

public class LectureSchema
{
    public Guid Id { get; set; }
    public string Topic { get; set; }
    public ModuleSchema Module { get; set; }

    public LectureSchema(string topic, ModuleSchema module)
    {
        Id = new Guid();
        Topic = topic;
        Module = module;
    }

    public LectureSchema()
    {
    }
}