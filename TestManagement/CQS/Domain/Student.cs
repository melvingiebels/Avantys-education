namespace CQS.Domain;

public class Student
{
    public Student(Guid id, string firstName, string lastName, Guid courseId)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        CourseId = courseId;
    }

    public IEnumerable<Test> Tests { get; set; }
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid CourseId { get; set; }
}