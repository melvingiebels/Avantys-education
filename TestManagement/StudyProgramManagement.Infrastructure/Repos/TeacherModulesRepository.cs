using Microsoft.EntityFrameworkCore;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Context;

namespace StudyProgramManagement.Infrastructure.Repos;

public class TeacherModulesRepository:IRepository<TeacherModules>
{
    private readonly StudyProgramManagementDbContext _dbContext;

    public TeacherModulesRepository(StudyProgramManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<List<TeacherModules>> Get()
    {
        return _dbContext.TeacherModules.ToListAsync();
    }

    public Task<TeacherModules?> GetById(Guid guid)
    {
        return _dbContext.TeacherModules.FirstAsync(c => c.Id == guid)!;
    }

    public void Create(TeacherModules model)
    {
        _dbContext.TeacherModules.Add(model);
        _dbContext.SaveChanges();
    }

    public TeacherModules Update(TeacherModules model)
    {
        _dbContext.TeacherModules.Update(model);
        _dbContext.SaveChanges();
        return model;
    }
}