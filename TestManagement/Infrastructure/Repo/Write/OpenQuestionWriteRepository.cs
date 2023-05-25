using CQS.Domain.Questions;
using Infrastructure.Context;

namespace Infrastructure.Repo.Write;

public class OpenQuestionWriteRepository : IWriteRepository<OpenQuestion>
{
    private readonly TestManagementDbContext _dbContext;

    public OpenQuestionWriteRepository(TestManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(OpenQuestion questionWriteModelWriteModel)
    {
        _dbContext.OpenQuestions.Add(questionWriteModelWriteModel);
        _dbContext.SaveChanges();
    }

    public OpenQuestion Update(OpenQuestion questionWriteModelWriteModel)
    {
        _dbContext.OpenQuestions.Update(questionWriteModelWriteModel);
        _dbContext.SaveChanges();
        return _dbContext.OpenQuestions.Find(questionWriteModelWriteModel)!;
    }
}