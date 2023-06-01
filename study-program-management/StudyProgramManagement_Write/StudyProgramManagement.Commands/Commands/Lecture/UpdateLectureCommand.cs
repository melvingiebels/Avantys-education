namespace StudyProgramManagement.Commands.Commands.Lecture;

public class UpdateLectureCommand : UpdateCommand<Domain.Models.Lecture>, ICommand
{
    public UpdateLectureCommand(Domain.Models.Lecture model) : base(model)
    {
    }
}