using TestManagement.CQS.Command.Student;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.CommandHandlers.Student;

public class UpdateStudentCommandHandler : EFCommandHandlerBase<UpdateStudentCommand, TestManagementDbContext>
{
    public UpdateStudentCommandHandler(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(UpdateStudentCommand command)
    {
        DbContext.Students.Update(command.Student);
        DbContext.SaveChanges();
    }
}