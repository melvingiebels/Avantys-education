using System;

namespace StudyProgramManagement.Commands.Commands.Lecture;

public class RemoveLectureCommand : RemoveCommand, ICommand
{
    public RemoveLectureCommand(Guid id) : base(id)
    {
    }
}