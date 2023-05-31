using Microsoft.EntityFrameworkCore;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Context;

namespace StudyProgramManagement.Infrastructure.Repos;

public class StudyProgramRepository : IRepository<StudyProgram>
{
    private readonly StudyProgramManagementDbContext _dbContext;

    public StudyProgramRepository(StudyProgramManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<StudyProgram>> Get()
    {
        return _dbContext.StudyPrograms.ToListAsync();
    }

    public Task<StudyProgram?> GetById(Guid guid)
    {
        return _dbContext.StudyPrograms.FirstAsync(c => c.Id == guid)!;
    }

    public void Create(StudyProgram model)
    {
        _dbContext.StudyPrograms.Add(model);
        _dbContext.SaveChanges();
    }

    public StudyProgram Update(StudyProgram model)
    {
        _dbContext.StudyPrograms.Update(model);
        _dbContext.SaveChanges();
        return model;
    }
    public void Delete(Guid guid)
    {
        var studyProgramToBeRemoved = _dbContext.StudyPrograms.FirstAsync(c => c.Id == guid).Result;
        _dbContext.StudyPrograms.Remove(studyProgramToBeRemoved);
        _dbContext.SaveChanges();
    }
}