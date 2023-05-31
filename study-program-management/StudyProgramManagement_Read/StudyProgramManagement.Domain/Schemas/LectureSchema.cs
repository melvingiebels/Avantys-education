using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudyProgramManagement.Domain.Schemas;

[Serializable, BsonIgnoreExtraElements]
public class LectureSchema: Schema
{
    [BsonId, BsonElement("_id")]
    public Guid Id { get; set; }
    [BsonElement("topic"), BsonRepresentation(BsonType.String)]
    public string Topic { get; set; }
    
    [BsonElement("module")]
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