using CQS.Queries.Student;
using Infrastructure.Context;
using Infrastructure.Core;

namespace Infrastructure.QueriesHandlers.Student;

public class GetStudents : EFQueryBase<TestManagementDbContext>, IGetStudents
{
    public GetStudents(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<CQS.Domain.Student> Excecute(Guid studentId)
    {
        return DbContext.Students.ToList();
    }
}