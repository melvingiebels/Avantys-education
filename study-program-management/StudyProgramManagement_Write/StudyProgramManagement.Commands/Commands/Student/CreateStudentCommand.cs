namespace StudyProgramManagement.Commands.Commands.Student;

public class CreateStudentCommand : CreateCommand<Domain.Models.Student>, ICommand
{
    public CreateStudentCommand(Domain.Models.Student model) : base(model)
    {
    }
}