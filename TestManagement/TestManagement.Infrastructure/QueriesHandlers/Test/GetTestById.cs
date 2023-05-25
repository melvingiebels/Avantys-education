using TestManagement.CQS.Queries;
using TestManagement.CQS.Queries.Test;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.QueriesHandlers.Test;

public class GetTestById : EFQueryBase<TestManagementDbContext>, IGetTestById
{
    public GetTestById(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public CQS.Domain.Test Excecute(Guid testId)
    {
        return DbContext.Tests.FirstOrDefault(t => t.Id == testId)!;
    }
}