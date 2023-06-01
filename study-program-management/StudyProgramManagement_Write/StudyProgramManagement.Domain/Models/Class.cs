using System.Text.Json.Serialization;
using StudyProgramManagement.Domain.Models.Enums;

namespace StudyProgramManagement.Domain.Models;

public class Class : Model
{
    public Class(List<Student> students, ClassNotation classNotation)
    {
        Students = students;
        ClassNotation = classNotation;
    }

    public Class()
    {
    }

    public Guid Id { get; set; }

    [JsonIgnore] public List<Student> Students { get; set; }

    public ClassNotation ClassNotation { get; set; }
}