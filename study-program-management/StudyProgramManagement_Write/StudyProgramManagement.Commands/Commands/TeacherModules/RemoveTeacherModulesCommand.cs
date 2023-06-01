using System;

namespace StudyProgramManagement.Commands.Commands.TeacherModules;

public class RemoveTeacherModulesCommand : RemoveCommand, ICommand
{
    public RemoveTeacherModulesCommand(Guid id) : base(id)
    {
    }
}