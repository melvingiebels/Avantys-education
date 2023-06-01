using Microsoft.EntityFrameworkCore;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Context;

namespace StudyProgramManagement.Infrastructure.Repos;

public class TeacherRepository : IRepository<Teacher>
{
    private readonly StudyProgramManagementDbContext _dbContext;

    public TeacherRepository(StudyProgramManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Teacher>> Get()
    {
        return _dbContext.Teachers.ToListAsync();
    }

    public Task<Teacher?> GetById(Guid guid)
    {
        return _dbContext.Teachers.FirstAsync(c => c.Id == guid)!;
    }

    public void Create(Teacher model)
    {
        _dbContext.Teachers.Add(model);
        _dbContext.SaveChanges();
    }

    public Teacher Update(Teacher model)
    {
        _dbContext.Teachers.Update(model);
        _dbContext.SaveChanges();
        return model;
    }

    public void Delete(Guid guid)
    {
        var teacherToBeRemoved = _dbContext.Teachers.FirstAsync(c => c.Id == guid).Result;
        _dbContext.Teachers.Remove(teacherToBeRemoved);
        _dbContext.SaveChanges();
    }
}