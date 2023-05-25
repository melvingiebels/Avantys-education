using CQS.Domain;
using Infrastructure.Context;

namespace Infrastructure.Repo.Write;

public class TestWriteRepository : IWriteRepository<Test>
{
    private readonly TestManagementDbContext _dbContext;

    public TestWriteRepository(TestManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(Test testWriteModel)
    {
        _dbContext.Tests.Add(testWriteModel);
        _dbContext.SaveChanges();
    }

    public Test Update(Test testWriteModel)
    {
        _dbContext.Tests.Update(testWriteModel);
        _dbContext.SaveChanges();
        return _dbContext.Tests.Find(testWriteModel) ?? new Test();
    }
}