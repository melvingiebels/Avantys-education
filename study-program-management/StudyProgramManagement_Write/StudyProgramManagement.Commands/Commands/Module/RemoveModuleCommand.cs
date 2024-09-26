using System;

namespace StudyProgramManagement.Commands.Commands.Module;

public class RemoveModuleCommand : RemoveCommand, ICommand
{
    public RemoveModuleCommand(Guid id) : base(id)
    {
    }
}