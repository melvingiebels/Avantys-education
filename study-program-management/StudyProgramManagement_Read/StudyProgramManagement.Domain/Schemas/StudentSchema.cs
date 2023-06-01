using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudyProgramManagement.Domain.Schemas;

[Serializable, BsonIgnoreExtraElements]
public class StudentSchema: Schema
{
    [BsonElement("firstname"), BsonRepresentation(BsonType.String)]
    public string FirstName { get; set; }
    [BsonElement("lastname"), BsonRepresentation(BsonType.String)]
    public string LastName { get; set; }
    [BsonElement("study_program")]
    public StudyProgramSchema StudyProgram { get; set; }
    public StudentSchema(Guid id, string firstName, string lastName, StudyProgramSchema studyProgramSchema): base(id)
    {
        Id = new Guid();
        FirstName = firstName;
        LastName = lastName;
        StudyProgram = studyProgramSchema;
    }
}