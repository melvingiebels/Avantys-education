using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using StudyProgramManagement.Domain.Enums;

namespace StudyProgramManagement.Domain.Schemas;

[Serializable, BsonIgnoreExtraElements]
public class ClassSchema : Schema
{
    [BsonElement("students")]
    public List<StudentSchema> Students { get; set; }
    [BsonElement("class_notation")]
    public ClassNotation ClassNotation { get; set; }

    public ClassSchema(Guid id, List<StudentSchema> students, ClassNotation classNotation): base(id)
    {
        Students = students;
        ClassNotation = classNotation;
    }
}

