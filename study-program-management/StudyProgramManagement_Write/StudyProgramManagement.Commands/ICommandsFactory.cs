namespace StudyProgramManagement.Commands;

public interface ICommandsFactory
{
    void ExecuteQuery<T>(T command)
        where T : ICommand;
}