namespace StudyProgramManagement.Commands.Commands.Lecture;

public class CreateLectureCommand : CreateCommand<Domain.Models.Lecture>, ICommand
{
    public CreateLectureCommand(Domain.Models.Lecture model) : base(model)
    {
    }
}