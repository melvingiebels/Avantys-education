using TestManagement.CQS.Queries;
using TestManagement.CQS.Queries.Question;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.QueriesHandlers.Question;

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