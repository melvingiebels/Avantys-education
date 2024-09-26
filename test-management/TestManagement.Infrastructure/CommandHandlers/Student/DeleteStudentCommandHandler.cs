using TestManagement.CQS.Command.Student;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.CommandHandlers.Student;

public class DeleteStudentCommandHandler : EFCommandHandlerBase<DeleteStudentCommand, TestManagementDbContext>
{
    public DeleteStudentCommandHandler(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(DeleteStudentCommand command)
    {
        DbContext.Students.Remove(command.Student);
        DbContext.SaveChanges();
    }
}