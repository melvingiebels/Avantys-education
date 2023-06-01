using Microsoft.EntityFrameworkCore;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Context;

namespace StudyProgramManagement.Infrastructure.Repos;

public class ModuleRepository : IRepository<Module>
{
    private readonly StudyProgramManagementDbContext _dbContext;

    public ModuleRepository(StudyProgramManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Module>> Get()
    {
        return _dbContext.Modules.ToListAsync();
    }

    public Task<Module?> GetById(Guid guid)
    {
        return _dbContext.Modules.FirstAsync(c => c.Id == guid)!;
    }

    public void Create(Module model)
    {
        _dbContext.Modules.Add(model);
        _dbContext.SaveChanges();
    }

    public Module Update(Module model)
    {
        _dbContext.Modules.Update(model);
        _dbContext.SaveChanges();
        return model;
    }

    public void Delete(Guid guid)
    {
        var moduleToBeRemoved = _dbContext.Modules.FirstAsync(c => c.Id == guid).Result;
        _dbContext.Modules.Remove(moduleToBeRemoved);
        _dbContext.SaveChanges();
    }
}