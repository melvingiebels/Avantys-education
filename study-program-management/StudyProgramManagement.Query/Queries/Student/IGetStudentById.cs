namespace StudyProgramManagement.Query.Queries.Student;

public interface IGetStudentById
{
    Task<Domain.Models.Student> Excecute(Guid id);

}