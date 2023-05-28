namespace StudyProgramManagement.Domain.Models;

public class Class
{
    public Guid Id { get; set; }
    public List<Student> Students { get; set; }
    public ClassNotation ClassNotation { get; set; }

    public Class(List<Student> students, ClassNotation classNotation)
    {
        Students = students;
        ClassNotation = classNotation;  
    }
}