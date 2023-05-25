using CQS.Domain;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repo.Read;

public class TestReadRepository : IReadRepository<Test>
{
    private readonly TestManagementDbContext _dbContext;


    public TestReadRepository(TestManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Test>> Get()
    {
        return _dbContext.Tests.ToListAsync();
    }

    public Task<Test?> GetById(Guid id)
    {
        return _dbContext.Tests.FindAsync(id).AsTask();
    }
}