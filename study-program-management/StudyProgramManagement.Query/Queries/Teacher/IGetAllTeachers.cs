namespace StudyProgramManagement.Query.Queries.Teacher;

public interface IGetAllTeachers
{
    IEnumerable<Domain.Models.Teacher> Excecute();
}