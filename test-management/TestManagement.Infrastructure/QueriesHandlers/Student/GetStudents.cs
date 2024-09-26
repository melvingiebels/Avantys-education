using TestManagement.CQS.Queries.Student;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.QueriesHandlers.Student;

public class GetStudents : EFQueryBase<TestManagementDbContext>, IGetStudents
{
    public GetStudents(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<CQS.Domain.Student> Excecute()
    {
        return DbContext.Students.ToList();
    }
}