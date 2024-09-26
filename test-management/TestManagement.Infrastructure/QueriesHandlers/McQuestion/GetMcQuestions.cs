using TestManagement.CQS.Queries;
using TestManagement.CQS.Queries.McQuestion;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.QueriesHandlers.McQuestion;

public class GetMcQuestions : EFQueryBase<TestManagementDbContext>, IGetMcQuestions
{
    public GetMcQuestions(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<CQS.Domain.Questions.McQuestion> Excecute()
    {
        return DbContext.McQuestions.ToList()!;
    }
}