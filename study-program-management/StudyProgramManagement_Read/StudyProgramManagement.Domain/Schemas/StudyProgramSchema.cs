using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudyProgramManagement.Domain.Schemas;

[Serializable, BsonIgnoreExtraElements]
public class StudyProgramSchema: Schema
{
    [BsonElement("name"), BsonRepresentation(BsonType.String)]
    public string Name { get; set; }
    [BsonElement("code"), BsonRepresentation(BsonType.String)]
    public string Code { get; set; }
    [BsonElement("total_ecs"), BsonRepresentation(BsonType.Int32)]
    public int TotalECs { get; set; }
    [BsonElement("modules")]
    public List<ModuleSchema> Modules { get; set; }
    [BsonElement("students")]
    public List<StudentSchema> Students { get; set; }
    public StudyProgramSchema(Guid id, int totalECs, List<ModuleSchema> modules, List<StudentSchema> students, string name, string code): base(id)
    {
        Id = new Guid();
        TotalECs = totalECs;
        Modules = modules;
        Students = students;
        Name = name;
        Code = code;
    }
}