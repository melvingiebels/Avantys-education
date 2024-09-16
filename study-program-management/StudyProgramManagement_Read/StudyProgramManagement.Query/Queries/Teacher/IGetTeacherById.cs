using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.Teacher;

public interface IGetTeacherById: IQuery
{
    Task<TeacherSchema> Excecute(Guid id);
}   