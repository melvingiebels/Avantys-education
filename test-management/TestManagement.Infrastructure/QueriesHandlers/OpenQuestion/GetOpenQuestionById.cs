using TestManagement.CQS.Queries;
using TestManagement.CQS.Queries.OpenQuestion;
using Microsoft.EntityFrameworkCore;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.QueriesHandlers.OpenQuestion;

public class GetOpenQuestionById : EFQueryBase<TestManagementDbContext>, IGetOpenQuestionById
{
    public GetOpenQuestionById(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public CQS.Domain.Questions.OpenQuestion Excecute(Guid questionId)
    {
        return DbContext.OpenQuestions.FirstOrDefault(q => q.Id == questionId)!;
    }
}