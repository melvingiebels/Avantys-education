using TestManagement.CQS.Queries;
using TestManagement.CQS.Queries.Test;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.QueriesHandlers.Test;

public class GetAllGradedTests : EFQueryBase<TestManagementDbContext>, IGetAllGradedTests
{
    public GetAllGradedTests(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<CQS.Domain.Test> Excecute()
    {
        var gTest = new List<CQS.Domain.Test>();
        DbContext.Tests.ToList().ForEach(t =>
        {
            if (t.Grade != 0)
                gTest.Add(t);
        });
        return gTest;
    }
}