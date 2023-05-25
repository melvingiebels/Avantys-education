namespace CQS.Command.Test;

public class CreateTestCommand : ICommand
{
    public readonly Domain.Test Test;

    public CreateTestCommand(Domain.Test test)
    {
        Test = test;
    }
}