using TestManagement.CQS.Queries;
using TestManagement.CQS.Queries.OpenQuestion;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.QueriesHandlers.OpenQuestion;

public class GetOpenQuestions : EFQueryBase<TestManagementDbContext>, IGetOpenQuestions
{
    public GetOpenQuestions(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<CQS.Domain.Questions.OpenQuestion> Excecute()
    {
        return DbContext.OpenQuestions.ToList();
    }
}