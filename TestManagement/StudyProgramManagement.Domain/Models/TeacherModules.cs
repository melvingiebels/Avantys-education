namespace StudyProgramManagement.Domain.Models;

public class TeacherModules
{
    public Guid Id { get; set; }
    public Guid ModuleId { get; set; }
    public Guid TeacherId { get; set; }

    public TeacherModules(Guid moduleId, Guid teacherId)
    {
        Id = new Guid();
        ModuleId = moduleId;
        TeacherId = teacherId;
    }

    public TeacherModules()
    {
    }
}