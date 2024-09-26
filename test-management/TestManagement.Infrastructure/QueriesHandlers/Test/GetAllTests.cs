using TestManagement.CQS.Queries;
using TestManagement.CQS.Queries.Test;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.QueriesHandlers.Test;

public class GetAllTests : EFQueryBase<TestManagementDbContext>, IGetAllTests
{
    public GetAllTests(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<CQS.Domain.Test> Excecute()
    {
        return DbContext.Tests.ToList();
    }
}