using CQS.Queries;
using CQS.Queries.McQuestion;
using Infrastructure.Context;
using Infrastructure.Core;

namespace Infrastructure.QueriesHandlers.McQuestion;

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