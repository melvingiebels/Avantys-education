using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudyProgramManagement.Domain.Schemas;

[Serializable, BsonIgnoreExtraElements]
public class LecturesScheduleSchema: Schema
{
    public LecturesScheduleSchema(Guid id, LectureSchema lecture): base(id)
    {
        Lecture = lecture;
    }

    [BsonElement("date_scheduled"), BsonRepresentation(BsonType.DateTime)]
    public DateTime DateScheduled { get; set; }
    [BsonElement("duration_in_minutes"), BsonRepresentation(BsonType.Int32)]
    public int DurationInMinutes { get; set; }
    [BsonElement("lecture")]
    public LectureSchema Lecture { get; set; }
}