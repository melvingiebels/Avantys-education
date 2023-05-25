using CQS.Queries;
using CQS.Queries.Question;
using Infrastructure.Context;
using Infrastructure.Core;

namespace Infrastructure.QueriesHandlers.Question;

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