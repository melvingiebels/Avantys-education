using TestManagement.CQS.Queries;
using TestManagement.CQS.Queries.McQuestion;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.QueriesHandlers.McQuestion;

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