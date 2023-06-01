using System;
using System.Text.Json.Serialization;

namespace StudyProgramManagement.Domain.Models;

public class LecturesSchedule : Model
{
    public LecturesSchedule(Lecture lecture)
    {
        Lecture = lecture;
    }

    public LecturesSchedule()
    {
    }

    public Guid Id { get; set; }
    public DateTime DateScheduled { get; set; }
    public int DurationInMinutes { get; set; }

    public virtual Guid LectureId { get; set; }

    [JsonIgnore] public virtual Lecture Lecture { get; set; }
}