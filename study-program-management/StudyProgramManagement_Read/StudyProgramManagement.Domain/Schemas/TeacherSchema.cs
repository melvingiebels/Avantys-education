using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudyProgramManagement.Domain.Schemas;

[Serializable, BsonIgnoreExtraElements]
public class TeacherSchema: Schema
{
    [BsonId, BsonElement("_id")]
    public Guid Id { get; set; }
    [BsonElement("firstname"), BsonRepresentation(BsonType.String)]
    public string FirstName { get; set; }
    
    [BsonElement("lastname"), BsonRepresentation(BsonType.String)]
    public string LastName { get; set; }
    
    [BsonElement("modules")]
    public List<ModuleSchema> Modules { get; set; }

    public TeacherSchema(string firstName, string lastName, List<ModuleSchema> modules)
    {
        Id = new Guid();
        FirstName = firstName;
        LastName = lastName;
        Modules = modules;
    }

    public TeacherSchema()
    {
    }
}