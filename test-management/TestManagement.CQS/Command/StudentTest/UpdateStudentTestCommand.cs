using TestManagement.CQS.Domain;

namespace TestManagement.CQS.Command.Student;

public class UpdateStudentTestCommand : ICommand
{
    public readonly StudentsTests StudentsTests;

    public UpdateStudentTestCommand(StudentsTests studentsTests)
    {
        StudentsTests = studentsTests;
    }
}