using StudyProgramManagement.Commands.Commands;
using StudyProgramManagement.Commands.Commands.Teacher;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.CommandHandlers.Teacher;

public class CreateTeacherCommandHandler: EFCommandHandlerBase<CreateTeacherCommand, StudyProgramManagementDbContext>
{
    public CreateTeacherCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(CreateTeacherCommand command)
    {
        DbContext.Teachers.Add(command.Model);
        DbContext.SaveChanges();
    }
}