namespace StudyProgramManagement.Commands.Commands.Teacher;

public class CreateTeacherCommand : CreateCommand<Domain.Models.Teacher>, ICommand
{
    public CreateTeacherCommand(Domain.Models.Teacher model) : base(model)
    {
    }
}