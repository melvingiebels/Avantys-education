using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.Student;

public interface IGetStudentById
{
    Task<StudentSchema> Excecute(Guid id);
}