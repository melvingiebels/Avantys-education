using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.Teacher;

public interface IGetTeacherById
{
    Task<TeacherSchema> Excecute(Guid id);
}   