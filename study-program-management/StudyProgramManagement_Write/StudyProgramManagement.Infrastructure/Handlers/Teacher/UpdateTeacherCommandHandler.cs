using StudyProgramManagement.Commands.Commands.Teacher;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.Teacher;

public class UpdateTeacherCommandHandler : EFCommandHandlerBase<UpdateTeacherCommand, StudyProgramManagementDbContext>
{
    public UpdateTeacherCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(UpdateTeacherCommand command)
    {
        DbContext.Teachers.Update(command.Model);
        DbContext.SaveChanges();
    }
}