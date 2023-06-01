namespace TestManagement.CQS.Command.Student;

public class AddTestToStudentCommand : ICommand
{
    public readonly Guid StudentId;
    public readonly Guid TestId;

    public AddTestToStudentCommand(Guid testId, Guid studentId)
    {
        TestId = testId;
        StudentId = studentId;
    }
}