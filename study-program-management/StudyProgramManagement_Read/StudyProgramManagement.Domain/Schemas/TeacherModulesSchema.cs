using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudyProgramManagement.Domain.Schemas;

[Serializable, BsonIgnoreExtraElements]
public class TeacherModulesSchema: Schema
{
    [BsonId, BsonElement("_id")]
    public Guid Id { get; set; }
    [BsonElement("module")]
    public ModuleSchema Module { get; set; }
    [BsonElement("teacher")]
    public TeacherSchema Teacher { get; set; }

    public TeacherModulesSchema(ModuleSchema module, TeacherSchema teacher)
    {
        Id = new Guid();
        Module = module;
        Teacher = teacher;
    }

    public TeacherModulesSchema()
    {
    }
}