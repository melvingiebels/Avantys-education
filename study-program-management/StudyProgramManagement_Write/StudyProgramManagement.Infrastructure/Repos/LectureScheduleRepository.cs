using Microsoft.EntityFrameworkCore;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.BusinessRules;
using StudyProgramManagement.Infrastructure.Context;

namespace StudyProgramManagement.Infrastructure.Repos;

public class LectureScheduleRepository : IRepository<LecturesSchedule>
{
    private readonly ScheduleLectureBusinessRules _businessRules;
    private readonly StudyProgramManagementDbContext _dbContext;

    public LectureScheduleRepository(StudyProgramManagementDbContext dbContext)
    {
        _dbContext = dbContext;
        _businessRules = new ScheduleLectureBusinessRules(dbContext);
    }

    public Task<List<LecturesSchedule?>> Get()
    {
        return _dbContext.LecturesSchedule.ToListAsync()!;
    }

    public Task<LecturesSchedule?> GetById(Guid guid)
    {
        return _dbContext.LecturesSchedule.FirstAsync(c => c.Id == guid)!;
    }

    public void Create(LecturesSchedule? model)
    {
        if (_businessRules.IsValid(model)) return;
        _dbContext.LecturesSchedule.Add(model);
        _dbContext.SaveChanges();
    }

    public LecturesSchedule? Update(LecturesSchedule model)
    {
        if (_businessRules.IsValid(model)) return null;
        _dbContext.LecturesSchedule.Update(model);
        _dbContext.SaveChanges();
        return model;
    }

    public void Delete(Guid guid)
    {
        var lectureScheduleToBeRemoved = _dbContext.LecturesSchedule.FirstAsync(c => c.Id == guid).Result;
        _dbContext.LecturesSchedule.Remove(lectureScheduleToBeRemoved);
        _dbContext.SaveChanges();
    }

    public Task<LecturesSchedule?> GetByLectureId(Guid lectureId)
    {
        return _dbContext.LecturesSchedule.FirstAsync(c => c.Lecture.Id == lectureId)!;
    }

    public Task<List<LecturesSchedule?>> GetByModuleId(Guid moduleId)
    {
        return _dbContext.LecturesSchedule.Where(c => c.Lecture.Module.Id == moduleId).ToListAsync()!;
    }
}