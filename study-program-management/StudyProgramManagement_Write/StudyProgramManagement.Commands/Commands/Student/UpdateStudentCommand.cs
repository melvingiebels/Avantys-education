namespace StudyProgramManagement.Commands.Commands.Student;

public class UpdateStudentCommand : UpdateCommand<Domain.Models.Student>, ICommand
{
    public UpdateStudentCommand(Domain.Models.Student model) : base(model)
    {
    }
}