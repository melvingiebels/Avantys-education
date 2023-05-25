using CQS.Domain.Questions;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repo.Read;

public class OpenQuestionReadRepository : IReadRepository<OpenQuestion>
{
    private readonly TestManagementDbContext _dbContext;

    public OpenQuestionReadRepository(TestManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<OpenQuestion>> Get()
    {
        return _dbContext.OpenQuestions.ToListAsync();
    }

    public Task<OpenQuestion?> GetById(Guid id)
    {
        return _dbContext.OpenQuestions.FindAsync(id).AsTask();
    }
}