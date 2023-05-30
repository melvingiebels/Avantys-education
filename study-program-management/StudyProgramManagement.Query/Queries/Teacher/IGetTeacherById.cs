namespace StudyProgramManagement.Query.Queries.Teacher;

public interface IGetTeacherById
{
    Task<Domain.Models.Teacher> Excecute(Guid id);
}   