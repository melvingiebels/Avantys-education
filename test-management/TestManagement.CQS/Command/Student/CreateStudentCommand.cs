namespace TestManagement.CQS.Command.Student;

public class CreateStudentCommand : ICommand
{
    public Domain.Student Student;

    public CreateStudentCommand(Domain.Student student)
    {
        Student = student;
    }
}