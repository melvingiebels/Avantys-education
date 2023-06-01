using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudyProgramManagement.Domain.Schemas;

[Serializable, BsonIgnoreExtraElements]
public class LectureSchema: Schema
{
    [BsonElement("topic"), BsonRepresentation(BsonType.String)]
    public string Topic { get; set; }
    
    [BsonElement("module")]
    public ModuleSchema Module { get; set; }

    public LectureSchema(Guid id,string topic, ModuleSchema module): base(id)
    {
        Id = new Guid();
        Topic = topic;
        Module = module;
    }
}