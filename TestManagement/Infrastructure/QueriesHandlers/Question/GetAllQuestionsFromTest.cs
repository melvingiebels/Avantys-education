using CQS.Queries;
using CQS.Queries.Question;
using Infrastructure.Context;
using Infrastructure.Core;

namespace Infrastructure.QueriesHandlers.Question;

public class GetAllQuestionsFromTest : EFQueryBase<TestManagementDbContext>, IGetAllQuestionsFromTest
{
    public GetAllQuestionsFromTest(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<CQS.Domain.Questions.Question> Excecute(Guid testId)
    {
        var qList = DbContext.TestQuestions.ToList();
        var qtList = new List<CQS.Domain.Questions.Question>();
        qList.ForEach(q =>
        {
            if (q.TestId == testId)
                qtList.Add(DbContext.Questions.FirstOrDefault(qs => qs.Id == q.Id)!);
        });
        return qtList;
    }
}