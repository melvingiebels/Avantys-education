namespace StudyProgramManagement.Commands.Commands.TeacherModules;

public class UpdateTeacherModulesCommand: UpdateCommand<Domain.Models.TeacherModules>, ICommand
{
    public UpdateTeacherModulesCommand(Domain.Models.TeacherModules model) : base(model)
    {
    }
}