using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Context;

namespace StudyProgramManagement.Infrastructure.BusinessRules;

public class ScheduleLectureBusinessRules
{
    private readonly StudyProgramManagementDbContext _dbContext;

    public ScheduleLectureBusinessRules(StudyProgramManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool IsValid(LecturesSchedule? lecturesSchedule)
    {
        return LectureShouldNotBeScheduledOnTheSameTimeAsAnotherLecture(lecturesSchedule) &&
               LectureShouldNotBeScheduledIfStartTimePlusDurationIsInAnotherDay(lecturesSchedule);
    }

    private bool LectureShouldNotBeScheduledOnTheSameTimeAsAnotherLecture(LecturesSchedule? lecturesSchedule)
    {
        // Retrieve the lectures scheduled on the same day as the given lecture
        var lecturesOnSameDay = _dbContext.LecturesSchedule.ToList()
            .Where(ls => ls.DateScheduled.Date == lecturesSchedule.DateScheduled.Date)
            .ToList();

        // Calculate the end time of the given lecture
        var givenLectureEndTime = lecturesSchedule.DateScheduled.AddMinutes(lecturesSchedule.DurationInMinutes);

        // Check if there are any overlapping lectures
        foreach (var lecture in lecturesOnSameDay)
        {
            // Calculate the end time of the current lecture
            var lectureEndTime = lecture.DateScheduled.AddMinutes(lecture.DurationInMinutes);

            // Check if the start time and end time of the lecture overlap with the given lecture
            if (lecturesSchedule.DateScheduled < lectureEndTime && lecture.DateScheduled < givenLectureEndTime)
                return false; // There is an overlap, so the lecture should not be scheduled
        }

        return true; // No overlapping lectures found, so the lecture can be scheduled
    }

    private bool LectureShouldNotBeScheduledIfStartTimePlusDurationIsInAnotherDay(LecturesSchedule? lecturesSchedule)
    {
        // Calculate the end time of the lecture
        var endTime = lecturesSchedule.DateScheduled.AddMinutes(lecturesSchedule.DurationInMinutes);

        // Check if the start and end times are in the same day
        return lecturesSchedule.DateScheduled.Date == endTime.Date;
    }
}