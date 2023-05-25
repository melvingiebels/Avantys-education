using CQS.Queries;
using CQS.Queries.McQuestion;
using Infrastructure.Context;
using Infrastructure.Core;

namespace Infrastructure.QueriesHandlers.McQuestion;

public class GetMcQuestionById : EFQueryBase<TestManagementDbContext>, IGetMcQuestionById
{
    public GetMcQuestionById(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public CQS.Domain.Questions.McQuestion? Excecute(Guid questionId)
    {
        return DbContext.McQuestions.FirstOrDefault(q => q!.Id == questionId);
    }
}