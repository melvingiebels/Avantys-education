using CQS.Queries;
using CQS.Queries.OpenQuestion;
using Infrastructure.Context;
using Infrastructure.Core;

namespace Infrastructure.QueriesHandlers.OpenQuestion;

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