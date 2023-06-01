using MongoDB.Bson.Serialization.Attributes;

namespace StudyProgramManagement.Domain.Schemas;

public abstract class Schema
{
    [BsonId, BsonElement("_id")]
    public Guid Id { get; set; }

    public Schema(Guid id)
    {
        Id = id;
    }
}