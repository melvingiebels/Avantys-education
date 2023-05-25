using CQS.Queries;
using CQS.Queries.Test;
using Infrastructure.Context;
using Infrastructure.Core;

namespace Infrastructure.QueriesHandlers.Test;

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