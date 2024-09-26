using Microsoft.EntityFrameworkCore;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Context;

namespace StudyProgramManagement.Infrastructure.Repos;

public class StudentRepository : IRepository<Student>
{
    private readonly StudyProgramManagementDbContext _dbContext;

    public StudentRepository(StudyProgramManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Student>> Get()
    {
        return _dbContext.Students.ToListAsync();
    }

    public Task<Student?> GetById(Guid guid)
    {
        return _dbContext.Students.FirstAsync(c => c.Id == guid)!;
    }

    public void Create(Student model)
    {
        _dbContext.Students.Add(model);
        _dbContext.SaveChanges();
    }

    public Student Update(Student model)
    {
        _dbContext.Students.Update(model);
        _dbContext.SaveChanges();
        return model;
    }

    public void Delete(Guid guid)
    {
        var studentToBeRemoved = _dbContext.Students.FirstAsync(c => c.Id == guid).Result;
        _dbContext.Students.Remove(studentToBeRemoved);
        _dbContext.SaveChanges();
    }
}