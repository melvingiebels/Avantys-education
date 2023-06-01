using StudyProgramManagement.Commands.Commands.StudyProgram;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.StudyProgram;

public class
    CreateStudyProgramCommandHandler : EFCommandHandlerBase<CreateStudyProgramCommand, StudyProgramManagementDbContext>
{
    public CreateStudyProgramCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(CreateStudyProgramCommand command)
    {
        DbContext.StudyPrograms.Add(command.Model);
        DbContext.SaveChanges();
    }
}