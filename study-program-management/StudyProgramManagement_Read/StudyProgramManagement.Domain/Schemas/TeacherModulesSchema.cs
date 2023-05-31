using System;

namespace StudyProgramManagement.Domain.Schemas;

public class TeacherModulesSchema
{
    public Guid Id { get; set; }
    public Guid ModuleId { get; set; }
    public Guid TeacherId { get; set; }

    public TeacherModulesSchema(Guid moduleId, Guid teacherId)
    {
        Id = new Guid();
        ModuleId = moduleId;
        TeacherId = teacherId;
    }

    public TeacherModulesSchema()
    {
    }
}