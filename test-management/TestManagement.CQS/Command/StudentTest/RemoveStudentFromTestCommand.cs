namespace TestManagement.CQS.Command.Student;

public class RemoveStudentFromTestCommand : ICommand
{
    public readonly Guid StudentId;
    public readonly Guid TestId;

    public RemoveStudentFromTestCommand(Guid testId, Guid studentId)
    {
        TestId = testId;
        StudentId = studentId;
    }
}