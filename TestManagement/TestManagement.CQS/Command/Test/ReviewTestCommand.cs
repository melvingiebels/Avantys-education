namespace TestManagement.CQS.Command.Test;

public class ReviewTestCommand : ICommand
{
    public readonly double Score;
    public readonly Guid StudentId;
    public readonly Guid TestId;

    public ReviewTestCommand(Guid testId, Guid studentId, double score)
    {
        TestId = testId;
        StudentId = studentId;
        Score = score;
    }
}