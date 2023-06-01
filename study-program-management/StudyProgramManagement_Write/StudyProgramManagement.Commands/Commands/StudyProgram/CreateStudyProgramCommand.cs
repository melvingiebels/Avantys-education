namespace StudyProgramManagement.Commands.Commands.StudyProgram;

public class CreateStudyProgramCommand : CreateCommand<Domain.Models.StudyProgram>, ICommand
{
    public CreateStudyProgramCommand(Domain.Models.StudyProgram model) : base(model)
    {
    }
}