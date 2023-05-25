using CQS.Queries.Student;
using Infrastructure.Context;
using Infrastructure.Core;

namespace Infrastructure.QueriesHandlers.Student;

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