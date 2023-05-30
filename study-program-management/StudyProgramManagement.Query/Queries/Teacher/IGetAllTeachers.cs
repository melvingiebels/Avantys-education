using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.Teacher;

public interface IGetAllTeachers
{
    IEnumerable<TeacherSchema> Excecute();
}