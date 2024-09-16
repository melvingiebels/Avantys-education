using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudyProgramManagement.Domain.Schemas;

[Serializable, BsonIgnoreExtraElements]
public class TeacherSchema: Schema
{
    [BsonElement("firstname"), BsonRepresentation(BsonType.String)]
    public string FirstName { get; set; }
    
    [BsonElement("lastname"), BsonRepresentation(BsonType.String)]
    public string LastName { get; set; }
    
    [BsonElement("modules")]
    public List<ModuleSchema> Modules { get; set; }

    public TeacherSchema(Guid id, string firstName, string lastName, List<ModuleSchema> modules): base(id)
    {
        Id = new Guid();
        FirstName = firstName;
        LastName = lastName;
        Modules = modules;
    }
}