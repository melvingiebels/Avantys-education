using CQS.Queries;
using CQS.Queries.Test;
using Infrastructure.Context;
using Infrastructure.Core;

namespace Infrastructure.QueriesHandlers.Test;

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