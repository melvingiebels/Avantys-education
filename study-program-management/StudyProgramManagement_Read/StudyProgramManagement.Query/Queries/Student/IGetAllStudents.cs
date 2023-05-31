using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.Student;

public interface IGetAllStudents
{
    IEnumerable<StudentSchema> Excecute();
}