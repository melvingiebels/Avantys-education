using Microsoft.EntityFrameworkCore;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.BusinessRules;
using StudyProgramManagement.Infrastructure.Context;

namespace StudyProgramManagement.Infrastructure.Repos;

public class LectureScheduleRepository : IRepository<LecturesSchedule>
{
    private readonly StudyProgramManagementDbContext _dbContext;
    private readonly ScheduleLectureBusinessRules _businessRules;

    public LectureScheduleRepository(StudyProgramManagementDbContext dbContext)
    {
        _dbContext = dbContext;
        _businessRules = new ScheduleLectureBusinessRules(dbContext);
    }

    public Task<List<LecturesSchedule>> Get()
    {
        return _dbContext.LecturesSchedule.ToListAsync()!;
    }

    public Task<LecturesSchedule?> GetById(Guid guid)
    {
        return _dbContext.LecturesSchedule.FirstAsync(c => c.Id == guid)!;
    }

    public void Create(LecturesSchedule? model)
    {
        if (_businessRules.LectureShouldNotBeScheduledOnTheSameTimeAsAnotherLecture(model)) return;
        _dbContext.LecturesSchedule.Add(model);
        _dbContext.SaveChanges();
    }

    public LecturesSchedule? Update(LecturesSchedule? model)
    {
        if (!_businessRules.LectureShouldNotBeScheduledOnTheSameTimeAsAnotherLecture(model)) return null;

        _dbContext.LecturesSchedule.Update(model);
        _dbContext.SaveChanges();
        return model;
    }
}