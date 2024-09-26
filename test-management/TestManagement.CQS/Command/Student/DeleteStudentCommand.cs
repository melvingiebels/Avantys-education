namespace TestManagement.CQS.Command.Student;

public class DeleteStudentCommand : ICommand
{
    public Domain.Student Student;

    public DeleteStudentCommand(Domain.Student student)
    {
        Student = student;
    }
}