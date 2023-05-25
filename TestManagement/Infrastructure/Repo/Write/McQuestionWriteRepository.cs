using CQS.Domain.Questions;
using Infrastructure.Context;

namespace Infrastructure.Repo.Write;

public class McQuestionWriteRepository : IWriteRepository<McQuestion>
{
    private readonly TestManagementDbContext _dbContext;

    public McQuestionWriteRepository(TestManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(McQuestion? questionWriteModelWriteModel)
    {
        _dbContext.McQuestions.Add(questionWriteModelWriteModel);
        _dbContext.SaveChanges();
    }

    public McQuestion? Update(McQuestion questionWriteModelWriteModel)
    {
        _dbContext.Questions.Update(questionWriteModelWriteModel);
        _dbContext.SaveChanges();
        return _dbContext.McQuestions.Find(questionWriteModelWriteModel)!;
    }
}