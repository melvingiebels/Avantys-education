using System;

namespace StudyProgramManagement.Domain.Schemas;

public class LecturesScheduleSchema
{
    public LecturesScheduleSchema(LectureSchema lecture)
    {
        Lecture = lecture;
    }

    public LecturesScheduleSchema()
    {
    }

    public Guid Id { get; set; }
    public DateTime DateScheduled { get; set; }
    public int DurationInMinutes { get; set; }
    public LectureSchema Lecture { get; set; }
}