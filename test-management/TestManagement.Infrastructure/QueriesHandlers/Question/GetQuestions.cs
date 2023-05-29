using TestManagement.CQS.Queries;
using TestManagement.CQS.Queries.Question;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.QueriesHandlers.Question;

public class GetQuestions : EFQueryBase<TestManagementDbContext>, IGetQuestions
{
    public GetQuestions(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<CQS.Domain.Questions.Question> Excecute()
    {
        return DbContext.Questions.ToList();
    }
}