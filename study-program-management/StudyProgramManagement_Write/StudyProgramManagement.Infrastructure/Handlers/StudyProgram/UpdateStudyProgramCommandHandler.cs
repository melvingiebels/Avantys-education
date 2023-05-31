using StudyProgramManagement.Commands.Commands.StudyProgram;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.CommandHandlers.StudyProgram;

public class UpdateStudyProgramCommandHandler: EFCommandHandlerBase<UpdateStudyProgramCommand, StudyProgramManagementDbContext>
{
    public UpdateStudyProgramCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(UpdateStudyProgramCommand command)
    {
        DbContext.StudyPrograms.Update(command.Model);
        DbContext.SaveChanges();
    }
}