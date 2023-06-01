using StudyProgramManagement.Commands.Commands.Lecture;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.Lecture;

public class CreateLectureCommandHandler : EFCommandHandlerBase<CreateLectureCommand, StudyProgramManagementDbContext>
{
    public CreateLectureCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(CreateLectureCommand command)
    {
        DbContext.Lectures.Add(command.Model);
        DbContext.SaveChanges();
    }
}