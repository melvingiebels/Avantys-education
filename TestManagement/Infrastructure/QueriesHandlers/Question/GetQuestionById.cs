using CQS.Queries;
using CQS.Queries.Question;
using Infrastructure.Context;
using Infrastructure.Core;

namespace Infrastructure.QueriesHandlers.Question;

public class GetQuestionById : EFQueryBase<TestManagementDbContext>, IGetQuestionById
{
    public GetQuestionById(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public CQS.Domain.Questions.Question Excecute(Guid questionId)
    {
        return DbContext.Questions.FirstOrDefault(q => q.Id == questionId)!;
    }
}