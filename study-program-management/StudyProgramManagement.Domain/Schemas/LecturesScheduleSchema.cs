using System.Text.Json.Serialization;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Domain.Schemas;

public class LecturesScheduleSchema
{
    public LecturesScheduleSchema(Lecture lecture)
    {
        Lecture = lecture;
    }

    public LecturesScheduleSchema()
    {
    }

    public Guid Id { get; set; }
    public DateTime DateScheduled { get; set; }
    public int DurationInMinutes { get; set; }
    public Lecture Lecture { get; set; }
}