namespace StudyProgramManagement.Query.Queries.Student;

public interface IGetAllStudents
{
    IEnumerable<Domain.Models.Student> Excecute();
}