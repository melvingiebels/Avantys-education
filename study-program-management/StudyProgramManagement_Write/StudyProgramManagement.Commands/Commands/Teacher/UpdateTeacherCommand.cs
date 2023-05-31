namespace StudyProgramManagement.Commands.Commands.Teacher;

public class UpdateTeacherCommand: UpdateCommand<Domain.Models.Teacher>, ICommand
{
    public UpdateTeacherCommand(Domain.Models.Teacher model) : base(model)
    {
    }
}