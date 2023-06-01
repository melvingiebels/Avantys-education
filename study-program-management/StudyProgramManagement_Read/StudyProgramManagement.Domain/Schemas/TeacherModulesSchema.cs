using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudyProgramManagement.Domain.Schemas;

[Serializable, BsonIgnoreExtraElements]
public class TeacherModulesSchema: Schema
{
    [BsonElement("module")]
    public ModuleSchema Module { get; set; }
    [BsonElement("teacher")]
    public TeacherSchema Teacher { get; set; }

    public TeacherModulesSchema(Guid id, ModuleSchema module, TeacherSchema teacher): base(id)
    {
        Id = new Guid();
        Module = module;
        Teacher = teacher;
    }
}