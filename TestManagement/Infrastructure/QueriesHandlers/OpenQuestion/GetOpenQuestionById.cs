using CQS.Queries;
using CQS.Queries.OpenQuestion;
using Infrastructure.Context;
using Infrastructure.Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.QueriesHandlers.OpenQuestion;

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