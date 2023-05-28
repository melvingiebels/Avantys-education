using Microsoft.EntityFrameworkCore;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Context;

namespace StudyProgramManagement.Infrastructure.Repos;

public class ClassRepository:IRepository<Class>
{
    private readonly StudyProgramManagementDbContext _dbContext;

    public ClassRepository(StudyProgramManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Class>> Get()
    {
        return _dbContext.Classes.ToListAsync();
    }

    public Task<Class?> GetById(Guid guid)
    {
       return _dbContext.Classes.FirstAsync(c => c.Id == guid)!;
    }

    public void Create(Class model)
    {
        _dbContext.Classes.Add(model);
        _dbContext.SaveChanges();
    }

    public Class Update(Class model)
    {
        _dbContext.Classes.Update(model);
        _dbContext.SaveChanges();
        return model;
    }
}