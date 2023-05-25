using CQS.Command.Student;
using Infrastructure.Context;
using Infrastructure.Core;

namespace Infrastructure.CommandHandlers.Student;

public class CreateStudentCommandHandler : EFCommandHandlerBase<CreateStudentCommand, TestManagementDbContext>
{
    public CreateStudentCommandHandler(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(CreateStudentCommand command)
    {
        DbContext.Students.Add(command.Student);
        DbContext.SaveChanges();
    }
}