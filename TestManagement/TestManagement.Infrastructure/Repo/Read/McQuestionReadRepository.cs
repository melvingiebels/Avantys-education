using TestManagement.CQS.Domain.Questions;
using Microsoft.EntityFrameworkCore;
using TestManagement.Infrastructure.Context;

namespace TestManagement.Infrastructure.Repo.Read;

public class McQuestionReadRepository : IReadRepository<McQuestion>
{
    private readonly TestManagementDbContext _dbContext;

    public McQuestionReadRepository(TestManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<McQuestion?>> Get()
    {
        return _dbContext.McQuestions.ToListAsync();
    }

    public Task<McQuestion?> GetById(Guid id)
    {
        return _dbContext.McQuestions.FindAsync(id).AsTask();
    }
}