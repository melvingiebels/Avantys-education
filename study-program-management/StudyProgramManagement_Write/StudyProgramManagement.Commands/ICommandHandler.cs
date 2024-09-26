using System;

namespace StudyProgramManagement.Commands;

public interface ICommandHandler<in TCommand> : IDisposable
    where TCommand : ICommand
{
    void Execute(TCommand command);
}