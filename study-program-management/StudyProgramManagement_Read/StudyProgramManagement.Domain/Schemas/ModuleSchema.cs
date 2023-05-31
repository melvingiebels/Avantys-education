using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using StudyProgramManagement.Domain.Enums;

namespace StudyProgramManagement.Domain.Schemas;

[Serializable, BsonIgnoreExtraElements]
public class ModuleSchema: Schema
{
    [BsonId, BsonElement("_id")]
    public Guid Id { get; set; }
    [BsonElement("ecs"), BsonRepresentation(BsonType.Int32)]
    public int ECs { get; set; }
    [BsonElement("name"), BsonRepresentation(BsonType.String)]
    public string Name { get; set; }
    [BsonElement("block"), BsonRepresentation(BsonType.String)]
    public Block Block { get; set; }
    [BsonElement("lectures"), BsonRepresentation(BsonType.String)]
    public List<LectureSchema> Lectures { get; set; }
    [BsonElement("teachers"), BsonRepresentation(BsonType.String)]
    public List<TeacherSchema> Teachers { get; set; }
    [BsonElement("classes"), BsonRepresentation(BsonType.String)]
    public List<ClassSchema> Classes { get; set; }

    public ModuleSchema(List<LectureSchema> lectures, List<TeacherSchema> teachers, string name, Block block, List<ClassSchema> classes,
        int eCs)
    {
        Id = new Guid();
        Lectures = lectures;
        Teachers = teachers;
        Name = name;
        Block = block;
        Classes = classes;
        ECs = eCs;
    }

    public ModuleSchema()
    {
    }
}