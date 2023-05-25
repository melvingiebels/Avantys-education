namespace CQS.Command;

public interface ICommandsFactory
{
    void ExecuteQuery<T>(T command)
        where T : ICommand;
}