using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using StudyProgramManagement.Domain.Enums;

namespace StudyProgramManagement.Domain.Schemas;

[Serializable, BsonIgnoreExtraElements]
public class ClassSchema : Schema
{
    [BsonId, BsonElement("_id")]
    public Guid Id { get; set; }
    [BsonElement("students")]
    public List<StudentSchema> Students { get; set; }
    [BsonElement("class_notation")]
    public ClassNotation ClassNotation { get; set; }

    public ClassSchema(List<StudentSchema> students, ClassNotation classNotation)
    {
        Students = students;
        ClassNotation = classNotation;
    }

    public ClassSchema()
    {
    }
}

