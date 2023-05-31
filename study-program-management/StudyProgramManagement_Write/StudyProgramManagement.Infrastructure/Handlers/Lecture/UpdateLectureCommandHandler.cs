using StudyProgramManagement.Commands.Commands.Lecture;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.CommandHandlers.Lecture;

public class UpdateLectureCommandHandler: EFCommandHandlerBase<UpdateLectureCommand, StudyProgramManagementDbContext>
{
    public UpdateLectureCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(UpdateLectureCommand command)
    {
        DbContext.Lectures.Update(command.Model);
        DbContext.SaveChanges();
    }
}