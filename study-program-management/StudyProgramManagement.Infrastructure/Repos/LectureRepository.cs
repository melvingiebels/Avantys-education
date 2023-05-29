using Microsoft.EntityFrameworkCore;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Context;

namespace StudyProgramManagement.Infrastructure.Repos;

public class LectureRepository:IRepository<Lecture>
{
    private readonly StudyProgramManagementDbContext _dbContext;

    public LectureRepository(StudyProgramManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<List<Lecture>> Get()
    {
        return _dbContext.Lectures.ToListAsync();
    }

    public Task<Lecture?> GetById(Guid guid)
    {
        return _dbContext.Lectures.FirstAsync(c => c.Id == guid)!;
    }

    public void Create(Lecture model)
    {
        _dbContext.Lectures.Add(model);
        _dbContext.SaveChanges();
    }

    public Lecture Update(Lecture model)
    {
        _dbContext.Lectures.Update(model);
        _dbContext.SaveChanges();
        return model;
    }
    public void Delete(Guid guid)
    {
        var lectureToBeRemoved = _dbContext.Lectures.FirstAsync(c => c.Id == guid).Result;
        _dbContext.Lectures.Remove(lectureToBeRemoved);
        _dbContext.SaveChanges();
    }
}