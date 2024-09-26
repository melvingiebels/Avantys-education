namespace TestManagement.CQS.Command.Test;

public class DeleteTestCommand : ICommand
{
    public readonly Domain.Test Test;

    public DeleteTestCommand(Domain.Test test)
    {
        Test = test;
    }
}