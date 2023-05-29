using System.Text.Json.Serialization;

namespace StudyProgramManagement.Domain.Models;

public class LecturesSchedule
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
    [JsonIgnore]
    public Lecture Lecture { get; set; }
}