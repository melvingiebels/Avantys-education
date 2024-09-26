namespace StudyProgramManagement.Commands.Commands.TeacherModules;

public class CreateTeacherModulesCommand : CreateCommand<Domain.Models.TeacherModules>, ICommand
{
    public CreateTeacherModulesCommand(Domain.Models.TeacherModules model) : base(model)
    {
    }
}