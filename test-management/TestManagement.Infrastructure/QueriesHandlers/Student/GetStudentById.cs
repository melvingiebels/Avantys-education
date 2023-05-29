using TestManagement.CQS.Queries.Student;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.QueriesHandlers.Student;

public class GetStudentById : EFQueryBase<TestManagementDbContext>, IGetStudentById
{
    public GetStudentById(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public CQS.Domain.Student Excecute(Guid studentId)
    {
        return DbContext.Students.FirstOrDefault(s => s.Id == studentId)!;
    }
}