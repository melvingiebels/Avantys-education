namespace TestManagement.CQS.Command.Student;

public class UpdateStudentCommand : ICommand
{
    public Domain.Student Student;

    public UpdateStudentCommand(Domain.Student student)
    {
        Student = student;
    }
}