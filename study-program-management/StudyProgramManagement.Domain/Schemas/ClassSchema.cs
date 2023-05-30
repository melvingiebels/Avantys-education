using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Domain.Models.Enums;

namespace StudyProgramManagement.Domain.Schemas;

public class ClassSchema
{
    public Guid Id { get; set; }
    public List<Student> Students { get; set; }
    public ClassNotation ClassNotation { get; set; }

    public ClassSchema(List<Student> students, ClassNotation classNotation)
    {
        Students = students;
        ClassNotation = classNotation;
    }

    public ClassSchema()
    {
    }
}