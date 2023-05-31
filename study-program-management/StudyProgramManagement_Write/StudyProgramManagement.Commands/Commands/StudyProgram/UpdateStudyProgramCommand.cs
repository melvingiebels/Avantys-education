namespace StudyProgramManagement.Commands.Commands.StudyProgram;

public class UpdateStudyProgramCommand: UpdateCommand<Domain.Models.StudyProgram>, ICommand
{
    public UpdateStudyProgramCommand(Domain.Models.StudyProgram model) : base(model)
    {
    }
}