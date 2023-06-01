using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.Student;

public interface IGetStudentById: IQuery
{
    Task<StudentSchema> Excecute(Guid id);
}