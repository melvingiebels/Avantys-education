namespace StudyProgramManagement.Query.Queries.TeacherModules;

public interface IGetAllTeacherModules
{
    IEnumerable<Domain.Models.TeacherModules> Excecute();
}